/**
 * The code-behind for the App class, which is responsible for 
 * instantiating the first page that will be displayed by the 
 * application on each platform, and for handling application 
 * lifecycle events.
 */

using System;
using System.IO;
using Xamarin.Forms;

using FirstMobileApp.Data;

namespace FirstMobileApp
{
    public partial class App : Application
    {
        //public static string FolderPath { get; private set; }

        static NoteDatabase database;

        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
