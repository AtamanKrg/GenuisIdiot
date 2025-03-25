using System;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите ваше имя:");
            string userName = Console.ReadLine();

            int countQuestions = 5;
            string[] questions = GetQuestions();
            int[] answers = GetAnswers();

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

                    int userAnswer = GetUserAnswer();

                    int rightAnswer = answers[i];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }

                string userDiagnose = GetUserDiagnose(countRightAnswers, countQuestions);
                Console.WriteLine($"Колличество правильных ответов: {countRightAnswers}");
                Console.WriteLine($"{userName}, ваш диагноз: {userDiagnose}");

                bool userChoice = GetUserChoice("Хотите заново пройти тест?");
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
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int userAnswer))
                { return userAnswer; }
                else
                { Console.WriteLine("Пожалуйста, введите число!"); }
            }
        }

        static string GetUserDiagnose(int countRightAnswer, int countQuestions)
        {
            string[] diagnoses = GetDiagnoses();
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
