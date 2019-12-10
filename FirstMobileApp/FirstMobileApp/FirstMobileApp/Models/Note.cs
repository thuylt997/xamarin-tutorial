/**
 * This class defines a Note model whose instances 
 * store data about each note in the application.
 */

using System;
using SQLite;

namespace FirstMobileApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        //public string fileName { get; set; }
        public int id { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
}
