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

        public List<Question> GetAll()
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

        public void ShowAll()
        {
            int i = 1;
            var sr = new StreamReader("questions.txt");
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split('#');
                Console.WriteLine($"{i}. {line[0]}");
                i++;
            }
            sr.Close();
        }

        public void Add(Question question)
        {
            var value = $"{question.Text}#{question.Answer}";
            new FileSystem().AppendToFile("questions.txt", value);
        }

        public void RemoveAt(int number)
        {
            var sr = new StreamReader("questions.txt");
            var questions = new List<string>();
            var index = 1;
            while (!sr.EndOfStream)
            {
                if (index != number)
                {
                    var line = sr.ReadLine();
                    questions.Add(line);
                }
                else
                {
                    var _ = sr.ReadLine();
                }
                index++;
            }
            sr.Close();
            var sw = new StreamWriter("questions.txt", false, Encoding.UTF8);
            foreach (var line in questions)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }
    }
}
