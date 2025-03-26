using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class UserResultsStorage
    {
        public List<User> Users { get; set; }

        public UserResultsStorage() { }

        public void ShowUserResults()
        {
            var sr = new StreamReader("results.txt", Encoding.UTF8);

            Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", "Имя", "Кол-во правильных ответов", "Диагноз");

            while (!sr.EndOfStream)
            {
                var userResult = sr.ReadLine();
                var user = userResult.Split('#');
                Console.WriteLine("|| {0, -15} || {1, -30} || {2, -10} ||", user[0], user[1], user[2]);
            }

        }

        public void SaveUserResult(User user)
        {
            var value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            new FileSystem().AppendToFile("results.txt", value);
        }
    }
}
