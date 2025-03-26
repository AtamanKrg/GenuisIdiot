using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class QuestionsStorage
    {
        public List<Question> Questions { get; set; } = new List<Question>()
        {
            new Question("Сколько будет два плюс два, умноженное на два?", 6),
            new Question("Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?", 9),
            new Question("На двух руках 10 пальцев, сколько пальцев на пяти руках?", 25),
            new Question("Укол делают каждые полчаса, сколько нужно минут, чтобы сделать три укола?", 60),
            new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
        };

        public List<Question> GetQuestions()
        {
            return Questions;
        }

    }
}
