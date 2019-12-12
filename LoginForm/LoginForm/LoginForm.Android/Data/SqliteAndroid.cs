using LoginForm.Droid.Data;
using LoginForm.Source.Data;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]

namespace LoginForm.Droid.Data
{
    public class SqliteAndroid : ISqlite
    {
        public SqliteAndroid() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}