using SQLite;
using System;

namespace LoginForm.Source.Models
{
    public class User
    {
        [PrimaryKey]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool AuthenticationChecking()
        {
            string myUsername = this.username;
            string myPassword = this.password;
            bool isValid = true;

            if (string.IsNullOrEmpty(myUsername) || string.IsNullOrEmpty(myPassword))
            {
                isValid = false;
            }

            if (String.Equals(myUsername, "admin") && String.Equals(myPassword, "admin"))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
