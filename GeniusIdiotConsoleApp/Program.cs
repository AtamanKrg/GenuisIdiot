using GeniusIdiot.Common;
using GeniusIdiotClassLibrary;
using System;
using System.Collections.Generic;

namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите ваше имя:");
            var user = new User(Console.ReadLine());
            Game game = new Game(user);

            while (true)
            {
                Console.Clear();

                while(!game.End())
                {
                    var currentQuestion = game.GetNextQuestion();

                    Console.WriteLine(game.GetQuestionNumberText());
                    Console.WriteLine(currentQuestion.Text);

                    var userAnswer = GetNumber();

                    game.AcceptAnswer(userAnswer);
                }

                var message = game.CalculateDiagnose();

                Console.WriteLine($"Колличество правильных ответов: {user.CountRightAnswers}");
                Console.WriteLine(message);

                var userChoice = GetUserChoice("Хотите посмотреть предыдущие результаты?");
                if (userChoice)
                {
                    ShowUserResults();
                }

                userChoice = GetUserChoice("Хотите добавить новый вопрос?");
                if (userChoice)
                {
                    AddNewQuestion();
                }

                userChoice = GetUserChoice("Хотите удалить существующий вопрос?");
                if (userChoice)
                {
                    RemoveQuestion();
                }

                userChoice = GetUserChoice("Хотите заново пройти тест?");
                if (!userChoice)
                {
                    break;
                }    
            }
        }

        static void ShowUserResults()
        {
            var userResults = UserResultsStorage.GetAll();

            Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", "Имя", "Кол-во правильных ответов", "Диагноз");

            foreach (var user in userResults)
            {
                Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", user.Name, user.CountRightAnswers, user.Diagnose);
            }

        }
        static void AddNewQuestion()
        {
            Console.WriteLine("Введите текст вопроса: ");
            string text = Console.ReadLine();
            Console.WriteLine("Введите числовой ответ на вопрос: ");
            int answer = GetNumber();

            QuestionsStorage.Add(new Question(text, answer));
        }
        static void RemoveQuestion()
        {
            var questions = QuestionsStorage.GetAll();
            for (int i = 0;  i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i].Text}");
            }
            Console.WriteLine("Введите номер удаляемого вопроса: ");
            while (true)
            {
                var number = GetNumber();
                if (number > questions.Count || number <= 0)
                {
                    Console.WriteLine($"Введите число от 1 до {questions.Count}");
                }
                else
                {
                    QuestionsStorage.Remove(questions[number - 1]);
                    break;
                }
            }
        }
        static int GetNumber()
        {
            int number;
            while (!InputValidator.TryParseToNumber(Console.ReadLine(), out number, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
            }
            return number;

        }
        static bool GetUserChoice(string message)
        {
            Console.WriteLine($"{message} Введите да или нет:");
            string boolUserAnswer;
            while (true)
            {
                boolUserAnswer = Console.ReadLine().ToLower();
                if (boolUserAnswer != "да" && boolUserAnswer != "нет")
                {
                    Console.WriteLine("Неверный ответ! Введите да или нет:");
                }
                else 
                {
                    if (boolUserAnswer == "да") { return true; }
                    else { return false; }
                }
            }
        }
    }
}
