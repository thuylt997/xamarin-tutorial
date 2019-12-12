using LoginForm.iOS.Data;
using LoginForm.Source.Data;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteIOS))]

namespace LoginForm.iOS.Data
{
    public class SqliteIOS : ISqlite
    {
        public SqliteIOS() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "Testdb.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, filename);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}