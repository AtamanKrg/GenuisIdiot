using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class FileSystem
    {
        public void AppendToFile(string fileName, string value)
        {
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
            sw.WriteLine(value);
            sw.Close();
        }
    }
}
