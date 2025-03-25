using System;
using System.Collections.Generic;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите ваше имя:");
            var userName = Console.ReadLine();

            int countQuestions = 5;
            var questions = GetQuestions();
            var answers = GetAnswers();

            while (true)
            {
                Console.Clear();
                int countRightAnswers = 0;

                Random random = new Random();
                for (int i = countQuestions - 1; i >= 1; i--)
                {
                    int j = random.Next(i + 1);

                    var tempQuestion = questions[j];
                    questions[j] = questions[i];
                    questions[i] = tempQuestion;

                    var tempAnswer = answers[j];
                    answers[j] = answers[i];
                    answers[i] = tempAnswer;
                }

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine($"{i + 1}. {questions[i]}");

                    var userAnswer = GetUserAnswer();

                    var rightAnswer = answers[i];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }

                var userDiagnose = GetUserDiagnose(countRightAnswers, countQuestions);
                SaveUserResult(userName, countRightAnswers, userDiagnose);
                Console.WriteLine($"Колличество правильных ответов: {countRightAnswers}");
                Console.WriteLine($"{userName}, ваш диагноз: {userDiagnose}");

                var userChoice = GetUserChoice("Хотите посмотреть все результаты?");
                if (userChoice)
                {
                    PrintResults();

                }

                userChoice = GetUserChoice("Хотите заново пройти тест?");
                if (!userChoice)
                {
                    break;
                }    
            }
        }

        static void PrintResults()
        {
            var userResults = GetUserResults();

            Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", "Имя", "Кол-во правильных ответов", "Диагноз");

            foreach (var userResult in userResults)
            {
                var user = userResult.Split('#');
                Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", user[0], user[1], user[2]);
            }
        }

        static List<string> GetUserResults()
        {
            var sr = new StreamReader("results.txt");
            var userResults = new List<string>();

            var line = sr.ReadLine();
            while (line != null)
            {
                userResults.Add(line);
                line = sr.ReadLine();
            }
            return userResults;
        }

        static void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            var sw = new StreamWriter("results.txt", true);
            sw.WriteLine($"{userName}#{countRightAnswers}#{diagnose}");
            sw.Close();
        }

        static int GetUserAnswer()
        {
            while (true)
            {
                var answer = Console.ReadLine();
                if (int.TryParse(answer, out int userAnswer))
                { return userAnswer; }
                else
                { Console.WriteLine("Пожалуйста, введите число!"); }
            }
        }

        static string GetUserDiagnose(int countRightAnswer, int countQuestions)
        {
            var diagnoses = GetDiagnoses();
            double percentage = (double)countRightAnswer / countQuestions * 100;
            if (percentage == 0) { return diagnoses[0]; }
            else if (percentage > 0 && percentage <= 25) { return diagnoses[1]; }
            else if (percentage > 25 && percentage <= 50) { return diagnoses[2]; }
            else if (percentage > 50 && percentage <= 75) { return diagnoses[3]; }
            else if (percentage > 75 && percentage < 100) { return diagnoses[4]; }
            else { return diagnoses[5]; }
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
        static string[] GetQuestions()
        {
            return new string[]
            {
                "Сколько будет два плюс два, умноженное на два?",
                "Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?",
                "На двух руках 10 пальцев, сколько пальцев на пяти руках?",
                "Укол делают каждые полчаса, сколько нужно минут, чтобы сделать три укола?",
                "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
        }

        static int[] GetAnswers()
        {
            return new int[] { 6, 9, 25, 60, 2 };
        }

        static string[] GetDiagnoses()
        {
            return new string[] { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };
        }
    }
}
