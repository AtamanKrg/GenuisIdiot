using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusIdiotClassLibrary
{
    public class QuestionsStorage
    {
        private static readonly string path = "questions.txt";
        public static List<Question> GetAll()
        {
            if (!FileProvider.Exists(path))
            {
                FileProvider.Append(path, "Сколько будет два плюс два, умноженное на два?#6");
                FileProvider.Append(path, "Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?#9");
                FileProvider.Append(path, "На двух руках 10 пальцев, сколько пальцев на пяти руках?#25");
                FileProvider.Append(path, "Укол делают каждые полчаса, сколько нужно минут, чтобы сделать три укола?#60");
                FileProvider.Append(path, "Пять свечей горело, две потухли. Сколько свечей осталось?#2");
            }

            var questions = new List<Question>();
            var value = FileProvider.GetValue(path);
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
            FileProvider.Append(path, value);
        }

        private static void SaveQuestions(List<Question> questions)
        {
            foreach (var question in questions)
            {
                Add(question);
            }
        }
        public static void Remove(Question removedQuestion)
        {
            var questions = GetAll();
            
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == removedQuestion.Text)
                {
                    questions.RemoveAt(i);
                }
            }

            FileProvider.Clear(path);

            SaveQuestions(questions);
        }
    }
}
