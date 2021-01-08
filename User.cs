using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bank
{
    public class User
    {
        private static string _aviableUsers = Environment.CurrentDirectory +@"\Users.csv";
        private string _userName;
        private string _password;
        public string UserName
        {
            get
            {
                return _userName;
            }
        }
        private User(string Name, string password)
        {
            _userName = Name;
            _password = password;
        }
        public static User GetUser(string Name, string Password)
        { 
            bool isFound = false;
            User res = null;
            using (StreamReader r =new StreamReader(_aviableUsers))
            {
                while(!r.EndOfStream && !isFound)
                {
                    string[] s = r.ReadLine().Split(',');
                    isFound = s[0] == Name && s[1] == Password;
                }    
            }
            if (isFound)
                res = new User(Name, Password);
            return res;
        }
    }
}
