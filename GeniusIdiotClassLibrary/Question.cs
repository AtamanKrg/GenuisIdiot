﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiot.Common
{
    public class Question
    {
        public string Text { get; set; }
        public int Answer { get; set; }

        public Question(string text, int answer)
        {
            Text = text;
            Answer = answer;
        }
    }
}
