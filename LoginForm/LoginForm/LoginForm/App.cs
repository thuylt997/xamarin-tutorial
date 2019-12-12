using LoginForm.Source.Data;
using LoginForm.Source.Views;
using Xamarin.Forms;

namespace LoginForm
{
    public class App : Application
    {
        static UserDbController userDbController;
        static TokenDbController tokenDbController;

        public App()
        {
            MainPage = new NavigationPage(new LoginPage());
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