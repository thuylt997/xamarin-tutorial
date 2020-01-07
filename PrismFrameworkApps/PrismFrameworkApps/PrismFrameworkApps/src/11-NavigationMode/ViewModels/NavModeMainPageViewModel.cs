using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._11_NavigationMode.ViewModels
{
    public class NavModeMainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand SecondPageCommand { get; set; }

        public NavModeMainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SecondPageCommand = new DelegateCommand(NavigateToSecondPageExecuted);
        }

        async void NavigateToSecondPageExecuted() =>
            await _navigationService.NavigateAsync("SecondPage");
    }
}
