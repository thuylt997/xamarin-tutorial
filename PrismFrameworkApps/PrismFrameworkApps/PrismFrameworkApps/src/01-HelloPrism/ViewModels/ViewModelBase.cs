using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismFrameworkApps.src._16_EventAggregator.Navigation;
using System;
using System.Collections.Generic;

namespace PrismFrameworkApps.src._01_HelloPrism.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigatedAware
    {
        protected INavigationService _navigationService { get; }

        public string Title { get; }

        public DelegateCommand GoHomeCommand { get; }
        public DelegateCommand BackToMenuCommand { get; }
        public DelegateCommand<string> NavigateCommand { get; }
        public DelegateCommand NavigateToMasterDetailPage { get; }
        public DelegateCommand NavigateToTabbedPage { get; }
        public DelegateCommand NavigateToNavigationPage { get; }
        public DelegateCommand GoToEventAggregatorCommand { get; }

        private IEnumerable<string> messages;

        private int initializedCount;

        private int onNavigatedFromCount;

        private int onNavigatedToCount;

        // Creating Accessors (Getters and Setters)
        public IEnumerable<string> Messages
        {
            get => messages;
            set => SetProperty(ref messages, value);
        }

        public int InitializedCount
        {
            get => initializedCount;
            set => SetProperty(ref initializedCount, value, UpdateMessage);
        }

        public int OnNavigatedFromCount
        {
            get => onNavigatedFromCount;
            set => SetProperty(ref onNavigatedFromCount, value, UpdateMessage);
        }

        public int OnNavigatedToCount
        {
            get => onNavigatedToCount;
            set => SetProperty(ref onNavigatedToCount, value, UpdateMessage);
        }

        void UpdateMessage()
        {
            Messages = new[]
            {
                $"Initialized Called: {InitializedCount} time(s)",
                $"OnNavigatedFrom Called: {OnNavigatedFromCount} time(s)",
                $"OnNavigatedTo Called: {OnNavigatedToCount} time(s)"
            };
        }

        // Constructor
        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = GetType().Name.Replace("ViewModel", string.Empty);

            GoHomeCommand = new DelegateCommand(OnGoHomeCommandExecuted);
            BackToMenuCommand = new DelegateCommand(OnBackToMenuCommandExecuted);
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
            NavigateToMasterDetailPage = new DelegateCommand(OnNavigateToMasterDetailPageExecuted);
            NavigateToTabbedPage = new DelegateCommand(OnNavigateToTabbedPageExecuted);
            NavigateToNavigationPage = new DelegateCommand(OnNavigateToNavigationPageExecuted);
            GoToEventAggregatorCommand = new DelegateCommand(OnGoToEventAggregatorCommandExecuted);
        }

        private async void OnGoToEventAggregatorCommandExecuted()
        {
            var result = await _navigationService.NavigateAsync(Navigate.Start);

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        async void OnNavigateToNavigationPageExecuted()
        {
            var result = await _navigationService.NavigateAsync(
                //new Uri("http://www.MyPrismFrameworkApps.com/CustomNavigationPage/LoginPage", UriKind.Absolute)
                new Uri("/CustomNavigationPage/LoginPage", UriKind.Absolute)
            );

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        async void OnNavigateToTabbedPageExecuted()
        {
            var result = await _navigationService.NavigateAsync(
                new Uri("/NavigationPage/CustomTabbedPage?selectedTab=MasterHomePage", UriKind.Absolute)
            );

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        async void OnNavigateToMasterDetailPageExecuted()
        {
            var result = await _navigationService.NavigateAsync(
                new Uri("/CustomMasterDetailPage/NavigationPage/MasterHomePage", UriKind.Absolute)
            );

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        async void OnNavigateCommandExecuted(string path)
        {
            // _navigationService.NavigateAsync("ViewB", useModalNavigation: true);
            // The statement above equivalent to CommandParameter Property's Value as "ViewB?useModalNavigation=True".

            var result = await _navigationService.NavigateAsync(path);

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        async void OnBackToMenuCommandExecuted()
        {
            var result = await _navigationService.NavigateAsync("/HomePageView");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        async void OnGoHomeCommandExecuted()
        {
            var result = await _navigationService.NavigateAsync("/NavigationPage/HelloPrismMainPage");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        public void Initialize(INavigationParameters parameters) => InitializedCount++;

        public void OnNavigatedFrom(INavigationParameters parameters) => OnNavigatedFromCount++;

        public void OnNavigatedTo(INavigationParameters parameters) => OnNavigatedToCount++;
    }
}
