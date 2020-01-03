using Prism.Commands;
using Prism.Navigation;
using System;

namespace PrismFrameworkApps.src._07_MasterDetailPages.ViewModels
{
    public class CustomMasterDetailPageViewModel
    {
        INavigationService _navigationService;

        public DelegateCommand<string> NavigateCommand { get; }

        public DelegateCommand BackToMenuCommand { get; }

        public CustomMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecuted);
            BackToMenuCommand = new DelegateCommand(BackToMenuCommandExecuted);
        }

        async void BackToMenuCommandExecuted() =>
            await _navigationService.NavigateAsync("/HomePageView");

        async void NavigateCommandExecuted(string page) =>
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
    }
}
