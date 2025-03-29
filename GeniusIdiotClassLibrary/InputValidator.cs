using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotClassLibrary
{
    public class InputValidator
    {
        public static bool TryParseToNumber(string input, out int number, out string errorMessage)
        {
            while (true)
            {
                try
                {
                    number = int.Parse(input);
                    errorMessage = "";
                    return true;
                }
                catch (FormatException)
                {
                    number = 0;
                    errorMessage = "Введите чиcло!";
                    return false;
                }
                catch (OverflowException)
                {
                    number = 0;
                    errorMessage = "Введите число от -2 * 10^9 до 2 * 10^9!";
                    return false;
                }
            }

        }
    }
}
