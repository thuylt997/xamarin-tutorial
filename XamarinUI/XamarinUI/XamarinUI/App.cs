using Xamarin.Forms;
using XamarinUI.Source.ActivityIndicatorExample;
using XamarinUI.Source.ProgressBarExample;

namespace XamarinUI
{
    public class App : Application
    {
        public App()
        {
            //MainPage = new NavigationPage(new ActivityIndicatorDisplayPage());
            MainPage = new NavigationPage(new ProgressBarDisplayPage());
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
