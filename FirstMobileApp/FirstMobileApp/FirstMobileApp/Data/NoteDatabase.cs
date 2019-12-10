/**
 * This class contains code to create the database, 
 * read data from it, write data to it, and delete data from it.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using FirstMobileApp.Models;
using SQLite;

namespace FirstMobileApp.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        //  The NoteDatabase constructor takes the path of the database file as an argument.
        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return database.Table<Note>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.id != 0)
            {
                return database.UpdateAsync(note);
            }
            else
            {
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return database.DeleteAsync(note);
        }
    }
}
