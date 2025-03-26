using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class QuestionsStorage
    {
        public QuestionsStorage() 
        {
            FileSystem fileSystem = new FileSystem();
            if (!fileSystem.Exists("questions.txt"))
            {
                fileSystem.AppendToFile("questions.txt", "Сколько будет два плюс два, умноженное на два?#6");
                fileSystem.AppendToFile("questions.txt", "Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?#9");
                fileSystem.AppendToFile("questions.txt", "На двух руках 10 пальцев, сколько пальцев на пяти руках?#25");
                fileSystem.AppendToFile("questions.txt", "Укол делают каждые полчаса, сколько нужно минут, чтобы сделать три укола?#60");
                fileSystem.AppendToFile("questions.txt", "Пять свечей горело, две потухли. Сколько свечей осталось?#2");
            }
        }

        public List<Question> GetQuestions()
        {
            var questions = new List<Question>();
            var sr = new StreamReader("questions.txt");
            while (!sr.EndOfStream) 
            {
                var line = sr.ReadLine().Split('#');
                var question = new Question(line[0], int.Parse(line[1]));
                questions.Add(question);
            }
            sr.Close();
            return questions;
        }

        public void Add(Question question)
        {
            var value = $"{question.Text}#{question.Answer}";
            new FileSystem().AppendToFile("questions.txt", value);
        }

    }
}
