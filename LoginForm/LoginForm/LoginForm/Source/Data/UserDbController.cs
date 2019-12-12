using LoginForm.Source.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LoginForm.Source.Data
{
    public class UserDbController
    {
        static object locker = new object();

        SQLiteConnection connection;

        public UserDbController()
        {
            connection = DependencyService.Get<ISqlite>().GetConnection();
            connection.CreateTable<User>();
        }

        public User GetUser()
        {
            lock (locker)
            {
                if (connection.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return connection.Table<User>().First();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.id != 0)
                {
                    connection.Update(user);

                    return user.id;
                }
                else
                {
                    return connection.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return connection.Delete<User>(id);
            }
        }
    }
}
