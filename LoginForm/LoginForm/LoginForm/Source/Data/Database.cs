/**
 * This class contains code to create the database, read data from it, 
 * and write data to it. The code uses asynchronous SQLite.NET APIs that
 * move database operations to background threads. In addition, the Database
 * constructor takes the path of the database file as an argument. 
 */

using LoginForm.Source.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginForm.Source.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return database.InsertAsync(person);
        }
    }
}
