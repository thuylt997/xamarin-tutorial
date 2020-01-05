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
using PrismFrameworkApps.src._04_ServicesRegistration.Interfaces;
using PrismFrameworkApps.src._04_ServicesRegistration.Services;
using PrismFrameworkApps.src._04_ServicesRegistration.ViewModels;
using PrismFrameworkApps.src._04_ServicesRegistration.Views;
using PrismFrameworkApps.src._05_PlatformSpecificServices.ViewModels;
using PrismFrameworkApps.src._05_PlatformSpecificServices.Views;
using PrismFrameworkApps.src._06_XamlNavigation.ViewModels;
using PrismFrameworkApps.src._06_XamlNavigation.Views;
using PrismFrameworkApps.src._07_MasterDetailPages.ViewModels;
using PrismFrameworkApps.src._07_MasterDetailPages.Views;
using PrismFrameworkApps.src._08_NavigationPages.ViewModels;
using PrismFrameworkApps.src._08_NavigationPages.Views;
using PrismFrameworkApps.src._09_TabbedPages.Views;
using PrismFrameworkApps.src._12_ViewModelLocator.ViewModels;
using PrismFrameworkApps.src._12_ViewModelLocator.Views;
using PrismFrameworkApps.src._16_PageLifecycle.ViewModels;
using PrismFrameworkApps.src._16_PageLifecycle.Views;
using PrismFrameworkApps.src._19_NavigationMode.ViewModels;
using PrismFrameworkApps.src._19_NavigationMode.Views;
using System;
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

            //var result = await NavigationService.NavigateAsync(
            //    new Uri("/CustomMasterDetailPage/NavigationPage/Test2Page", UriKind.Absolute)
            //);

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

            #region 03 - Prism ListView Example
            containerRegistry.RegisterForNavigation<ListSample, ListSampleViewModel>();
            containerRegistry.RegisterForNavigation<CityDetailPage, CityDetailPageViewModel>();
            #endregion 03 - Prism ListView Example

            #region 04 - Services Registration
            containerRegistry.RegisterForNavigation<ServicesMain, ServicesMainViewModel>();
            containerRegistry.RegisterForNavigation<TransientService, TransientServiceViewModel>();
            containerRegistry.RegisterForNavigation<SingletonService, SingletonServiceViewModel>();

            // Registering Transient Services
            containerRegistry.Register<IExampleAlphaService, ExampleAlphaService>();

            // Registering Singleton Services
            containerRegistry.RegisterSingleton<IExampleBetaService, ExampleBetaService>();
            #endregion 04 - Services Registration

            #region 05 - Platform Specific Services
            containerRegistry.RegisterForNavigation<PSSMain, PSSMainViewModel>();
            #endregion 05 - Platform Specific Services

            #region 06 - XAML Navigation
            containerRegistry.RegisterForNavigation<XamlNavMain, XamlNavMainViewModel>();
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>();
            #endregion 06 - XAML Navigation

            #region 07 - MasterDetailPages
            containerRegistry.RegisterForNavigation<CustomMasterDetailPage, CustomMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterHomePage>();
            containerRegistry.RegisterForNavigation<Test1Page, Test1PageViewModel>();
            containerRegistry.RegisterForNavigation<Test2Page>();
            #endregion 07 - MasterDetailPages

            #region 08 - NavigationPages
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<BatteryHomeMain, BatteryHomeMainViewModel>();
            #endregion 08 - NavigationPages

            #region 09 - TabbedPages
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            #endregion 09 - TabbedPages

            #region 12 - ViewModelLocator
            containerRegistry.RegisterForNavigation<VMLMainPage, VMLMainPageViewModel>();
            #endregion 12 - ViewModelLocator

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
