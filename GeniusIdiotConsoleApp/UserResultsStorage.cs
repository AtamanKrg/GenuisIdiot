using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiotConsoleApp
{
    public class UserResultsStorage
    {
        public static List<User> GetAll()
        {
            var value = FileProvider.GetValue("results.txt");
            var lines = value.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<User>(); 

            foreach (var line in lines)
            {
                var userResult = line.Split('#');
                var user = new User(userResult[0], int.Parse(userResult[1]), userResult[2]);
                results.Add(user);
            }
            return results;
        }

        public static void Save(User user)
        {
            var value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            FileProvider.Append("results.txt", value);
        }
    }
}
