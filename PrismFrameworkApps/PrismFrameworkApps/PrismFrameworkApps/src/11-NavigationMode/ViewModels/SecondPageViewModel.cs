using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._11_NavigationMode.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;

        private NavigationMode _navigationMode;

        public DelegateCommand ThirdPageCommand { get; }

        private bool _isVisible;

        public NavigationMode NavigationMode
        {
            get => _navigationMode;
            set => SetProperty(ref _navigationMode, value);
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public SecondPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ThirdPageCommand = new DelegateCommand(NavigateToThirdPageExecuted);
        }

        async void NavigateToThirdPageExecuted() =>
            await _navigationService.NavigateAsync("ThirdPage");

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode = parameters.GetNavigationMode();

            IsVisible = NavigationMode == NavigationMode.Back;
        }
    }
}
