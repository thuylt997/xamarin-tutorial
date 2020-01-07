using PersonalApp.RestApiDemo.ViewModels;
using PersonalApp.RestApiDemo.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System.Diagnostics;
using Xamarin.Forms;

namespace PersonalApp
{
    public partial class App : PrismApplication
    {
        public App() : this(null)
        {
            //InitializeComponent();

            //MainPage = new NavigationPage(new RestApiMain());
        }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<RestApiMain, RestApiMainViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("RestApiMain");

            if (!result.Success)
            {
                Debugger.Break();
            }
        }
    }
}
