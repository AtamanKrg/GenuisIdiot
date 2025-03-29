using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiot.Common
{
    public class DiagnoseCalculator
    {
        public static string Calculate(int countQuestions, User user)
        {
            var diagnoses = new List<string> { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };
            var percentage = user.CountRightAnswers * 100 / countQuestions;

            return diagnoses[percentage / 20];
        }
    }
}
