using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите ваше имя:");
            var user = new User(Console.ReadLine());

            while (true)
            {
                Console.Clear();

                user.CountRightAnswers = 0;
                var questions = QuestionsStorage.GetAll();

                var countQuestions = questions.Count;

                Random random = new Random();

                for (int i = 0; i < countQuestions; i++)
                {
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"{i + 1}. {questions[randomQuestionIndex].Text}");

                    var userAnswer = GetNumber();

                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        user.AcceptRightAnswer();
                    }

                    questions.RemoveAt(randomQuestionIndex);
                }

                user.Diagnose = GetUserDiagnose(user.CountRightAnswers, countQuestions);

                UserResultsStorage.Save(user);
                
                Console.WriteLine($"Колличество правильных ответов: {user.CountRightAnswers}");
                Console.WriteLine($"{user.Name}, ваш диагноз: {user.Diagnose}");

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
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите чиcло!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число от -2 * 10^9 до 2 * 10^9!");
                }
            }

        }
        static string GetUserDiagnose(int countRightAnswer, int countQuestions)
        {
            var diagnoses = GetDiagnoses();
            var percentage = countRightAnswer * 100 / countQuestions;

            return diagnoses[percentage / 20];
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
        static List<string> GetDiagnoses()
        {
            return new List<string> { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };
        }
    }
}
