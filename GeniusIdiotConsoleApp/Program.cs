using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите ваше имя:");
            User user = new User();
            user.Name = Console.ReadLine();

            while (true)
            {
                Console.Clear();

                user.CountRightAnswers = 0;
                QuestionsStorage questionsStorage = new QuestionsStorage();
                var questions = questionsStorage.GetAll();

                var countQuestions = questions.Count;

                Random random = new Random();

                for (int i = 0; i < countQuestions; i++)
                {
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"{i + 1}. {questions[randomQuestionIndex].Text}");

                    var userAnswer = GetUserAnswer();

                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        user.CountRightAnswers++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                }

                user.Diagnose = GetUserDiagnose(user.CountRightAnswers, countQuestions);

                UserResultsStorage userResultsStorage = new UserResultsStorage();
                userResultsStorage.SaveUserResult(user);
                
                Console.WriteLine($"Колличество правильных ответов: {user.CountRightAnswers}");
                Console.WriteLine($"{user.Name}, ваш диагноз: {user.Diagnose}");

                var userChoice = GetUserChoice("Хотите посмотреть предыдущие результаты?");
                if (userChoice)
                {
                    userResultsStorage.ShowUserResults();
                }

                userChoice = GetUserChoice("Хотите добавить новый вопрос?");
                if (userChoice)
                {
                    Console.WriteLine("Введите текст вопроса: ");
                    string text = Console.ReadLine();
                    Console.WriteLine("Введите числовой ответ на вопрос: ");
                    int answer = GetUserAnswer();
                    questionsStorage.Add(new Question(text, answer));
                }

                userChoice = GetUserChoice("Хотите удалить существующий вопрос?");
                if (userChoice)
                {
                    questionsStorage.ShowAll();
                    Console.WriteLine("Введите номер удаляемого вопроса: ");
                    while (true)
                    {
                        var number = GetUserAnswer();
                        if (number > countQuestions || number <= 0)
                        {
                            Console.WriteLine("Введите существующий номер вопроса!");
                        }
                        else
                        {
                            questionsStorage.RemoveAt(number);
                            break;
                        }
                    }
                }

                userChoice = GetUserChoice("Хотите заново пройти тест?");
                if (!userChoice)
                {
                    break;
                }    
            }
        }

        static int GetUserAnswer()
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
