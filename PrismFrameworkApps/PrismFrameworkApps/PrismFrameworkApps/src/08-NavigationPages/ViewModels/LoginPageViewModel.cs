using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace PrismFrameworkApps.src._08_NavigationPages.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        IPageDialogService _pageDialogService;

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand BackToMenuCommand { get; set; }

        private string username;

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            LoginCommand = new DelegateCommand(async () => await GoHomeExecuted());
            BackToMenuCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("/HomePageView"));
        }

        async Task GoHomeExecuted()
        {
            if (string.IsNullOrEmpty(Username))
            {
                await _pageDialogService.DisplayAlertAsync(
                    "Error",                // Title
                    "Username is required", // Dialog's content
                    "OK"                    // Choices
                );
            }
            else
            {
                await _navigationService.NavigateAsync(
                    new Uri($"BatteryHomeMain?Username={Username}", UriKind.Relative)
                );
            }
        }
    }
}
