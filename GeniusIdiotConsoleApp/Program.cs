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
            var userName = Console.ReadLine();

            var questions = GetQuestions();
            var answers = GetAnswers();
            var countQuestions = questions.Count;

            while (true)
            {
                Console.Clear();
                var countRightAnswers = 0;

                Random random = new Random();

                for (int i = 0; i < countQuestions; i++)
                {
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"{i + 1}. {questions[randomQuestionIndex]}");

                    var userAnswer = GetUserAnswer();

                    var rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                var userDiagnose = GetUserDiagnose(countRightAnswers, countQuestions);
                SaveUserResult(userName, countRightAnswers, userDiagnose);
                Console.WriteLine($"Колличество правильных ответов: {countRightAnswers}");
                Console.WriteLine($"{userName}, ваш диагноз: {userDiagnose}");

                var userChoice = GetUserChoice("Хотите посмотреть предыдущие результаты?");
                if (userChoice)
                {
                    ShowUserResults();

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
            var sr = new StreamReader("results.txt", Encoding.UTF8);

            Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", "Имя", "Кол-во правильных ответов", "Диагноз");

            while (!sr.EndOfStream)
            {
                var userResult = sr.ReadLine();
                var user = userResult.Split('#');
                Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", user[0], user[1], user[2]);
            }

        }

        static void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            var value = $"{userName}#{countRightAnswers}#{diagnose}";
            AppendToFile("results.txt", value);
        }

        static void AppendToFile(string fileName, string value) 
        {
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
            sw.WriteLine(value);
            sw.Close();
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
                    Console.WriteLine("Введите чило!");
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
        static List<string> GetQuestions()
        {
            return new List<string>
            {
                "Сколько будет два плюс два, умноженное на два?",
                "Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?",
                "На двух руках 10 пальцев, сколько пальцев на пяти руках?",
                "Укол делают каждые полчаса, сколько нужно минут, чтобы сделать три укола?",
                "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
        }

        static List<int> GetAnswers()
        {
            return new List<int> { 6, 9, 25, 60, 2 };
        }

        static List<string> GetDiagnoses()
        {
            return new List<string> { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };
        }
    }
}
