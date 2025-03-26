using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class User
    {
        public string Username {  get; set; }
        public int CountRightAnswers { get; set; }
        public string Diagnose { get; set; }

        public User() { }
    }
}
