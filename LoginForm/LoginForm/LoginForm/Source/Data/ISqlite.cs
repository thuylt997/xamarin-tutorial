using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginForm.Source.Data
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
