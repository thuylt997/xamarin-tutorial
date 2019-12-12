using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
            bool isValid = true;

            if (string.IsNullOrEmpty(this.username) || string.IsNullOrEmpty(this.password))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
