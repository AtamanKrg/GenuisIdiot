﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }

        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }
    }
}
