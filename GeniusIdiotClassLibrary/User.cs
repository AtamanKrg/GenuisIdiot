using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiot.Common
{
    public class User
    {
        public string Name {  get; set; }
        public int CountRightAnswers { get; set; }
        public string Diagnose { get; set; }

        public User(string name) 
        {
            Name = name;
            CountRightAnswers = 0;
            Diagnose = "Неизвестно";
        }

        public User(string name,  int countRightAnswers, string diagnose)
        {
            Name = name;
            CountRightAnswers = countRightAnswers;
            Diagnose = diagnose;
        }

        public void AcceptRightAnswer()
        {
            CountRightAnswers++;
        }
    }
}
