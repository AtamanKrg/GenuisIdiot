using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class User
    {
        public string Name {  get; set; }
        public int CountRightAnswers { get; set; } = 0;
        public string Diagnose { get; set; }

        public User() { }
    }
}
