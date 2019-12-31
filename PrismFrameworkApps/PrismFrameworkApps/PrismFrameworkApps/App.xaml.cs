using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PrismFrameworkApps.src;
using PrismFrameworkApps.src._00_AppLifecycle.ViewModels;
using PrismFrameworkApps.src._00_AppLifecycle.Views;
using PrismFrameworkApps.src._01_HelloPrism.ViewModels;
using PrismFrameworkApps.src._01_HelloPrism.Views;
using PrismFrameworkApps.src._02_PassingParameters.ViewModels;
using PrismFrameworkApps.src._02_PassingParameters.Views;
using PrismFrameworkApps.src._03_ListView.ViewModels;
using PrismFrameworkApps.src._03_ListView.Views;
using PrismFrameworkApps.src._12_ViewModelLocator.ViewModels;
using PrismFrameworkApps.src._12_ViewModelLocator.Views;
using PrismFrameworkApps.src._16_PageLifecycle.ViewModels;
using PrismFrameworkApps.src._16_PageLifecycle.Views;
using PrismFrameworkApps.src._19_NavigationMode.ViewModels;
using PrismFrameworkApps.src._19_NavigationMode.Views;
using Xamarin.Forms;

namespace PrismFrameworkApps
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("HomePageView");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // START - NavigationPage
            containerRegistry.RegisterForNavigation<NavigationPage>();
            // END - NavigationPage

            // START - Home Page (Menu)
            containerRegistry.RegisterForNavigation<HomePageView, HomePageViewModel>();
            // END - Home Page (Menu)

            // START - Application Lifecycle Example
            containerRegistry.RegisterForNavigation<AppLifecycleMainPage, AppLifecycleMainPageViewModel>();
            // END - Application Lifecycle Example

            // START - Hello Prism Example
            containerRegistry.RegisterForNavigation<HelloPrismMainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>();
            // END - Hello Prism Example

            // START - Passing Parameters Example
            containerRegistry.RegisterForNavigation<PassParamMainPage, PassParamMainPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();
            // END - Passing Parameters Example

            // START - Prism ListView Example
            containerRegistry.RegisterForNavigation<ListSample, ListSampleViewModel>();
            // END - Prism ListView Example

            // START - ViewModelLocator
            containerRegistry.RegisterForNavigation<VMLMainPage, VMLMainPageViewModel>();
            // END - ViewModelLocator

            // START - Page Lifecycle Example
            containerRegistry.RegisterForNavigation<PageLifecycleMainPage, PageLifecycleMainPageViewModel>();
            containerRegistry.RegisterForNavigation<PageLifecycleViewA, PageLifecycleViewAViewModel>();
            // END - Page Lifecycle Example

            // START - Navigation Mode Example
            containerRegistry.RegisterForNavigation<NavModeMainPage, NavModeMainPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
            containerRegistry.RegisterForNavigation<ThirdPage, ThirdPageViewModel>();
            // END - Navigation Mode Example
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            base.OnSleep();

            // TODO: This is the time to save app data in case the process is terminated.
            // This is the perfect timing to release exclusive resources (camera, I/O devices, etc...)
        }

        protected override void OnResume()
        {
            base.OnResume();

            // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
        }
    }
}
