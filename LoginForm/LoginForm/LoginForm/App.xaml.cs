using LoginForm.Source.Data;
using LoginForm.Source.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        static UserDbController userDbController;
        static TokenDbController tokenDbController;
        static Database database;

        const string displayText = "displayText";

        public string DisplayText { get; set; }

        /**
         * This code defines a Database property that creates a new
         * Database instance as a singleton. A local file path and 
         * filename, which represents where to store the database, 
         * are passed as the argument to the Database class constructor.
         */

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart() is executed");

            if (Properties.ContainsKey(displayText))
            {
                DisplayText = (string)Properties[displayText];
            }
        }

        protected override void OnSleep()
        {
            Console.WriteLine("OnSleep() is executed");

            Properties[displayText] = DisplayText;
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume() is executed");
        }

        public static UserDbController UserDatabase
        {
            get
            {
                if (userDbController == null)
                {
                    userDbController = new UserDbController();
                }

                return userDbController;
            }
        }

        public static TokenDbController TokenDatabase
        {
            get
            {
                if (tokenDbController == null)
                {
                    tokenDbController = new TokenDbController();
                }

                return tokenDbController;
            }
        }
    }
}