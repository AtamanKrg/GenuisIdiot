using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusIdiotConsoleApp
{
    public class QuestionsStorage
    {
        public static List<Question> GetAll()
        {
            if (!FileProvider.Exists("questions.txt"))
            {
                FileProvider.Append("questions.txt", "Сколько будет два плюс два, умноженное на два?#6");
                FileProvider.Append("questions.txt", "Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?#9");
                FileProvider.Append("questions.txt", "На двух руках 10 пальцев, сколько пальцев на пяти руках?#25");
                FileProvider.Append("questions.txt", "Укол делают каждые полчаса, сколько нужно минут, чтобы сделать три укола?#60");
                FileProvider.Append("questions.txt", "Пять свечей горело, две потухли. Сколько свечей осталось?#2");
            }

            var questions = new List<Question>();
            var value = FileProvider.GetValue("questions.txt");
            var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var values = line.Split('#');
                var question = new Question(values[0], int.Parse(values[1]));
                questions.Add(question);
            }
            return questions;
        }

        public static void Add(Question question)
        {
            var value = $"{question.Text}#{question.Answer}";
            FileProvider.Append("questions.txt", value);
        }

        private static void SaveQuestions(List<Question> questions)
        {
            foreach (var question in questions)
            {
                Add(question);
            }
        }
        public static void RemoveAt(int index)
        {
            var questions = GetAll();
            questions.RemoveAt(index);

            FileProvider.Clear("questions.txt");

            SaveQuestions(questions);
        }
    }
}
