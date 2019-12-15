/**
 * This code defines a Person class that will store data about 
 * each person in the application. The ID property is marked with 
 * PrimaryKey and AutoIncrement attributes to ensure that each Person 
 * instance in the database will have a unique id provided by SQLite.NET.
 */

using SQLite;

namespace LoginForm.Source.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
