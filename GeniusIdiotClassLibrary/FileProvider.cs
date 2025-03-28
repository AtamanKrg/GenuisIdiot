﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiot.Common
{
    public class FileProvider
    {
        public static void Append(string fileName, string value)
        {
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
            sw.WriteLine(value);
            sw.Close();
        }

        public static string GetValue(string fileName)
        {
            var sr = new StreamReader(fileName, Encoding.UTF8);
            var value = sr.ReadToEnd();
            sr.Close();
            return value;
        }

        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static void Clear(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);
        }
    }
}
