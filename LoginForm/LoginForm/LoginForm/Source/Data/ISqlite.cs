using SQLite;

namespace LoginForm.Source.Data
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
