using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._04_ServicesRegistration.ViewModels
{
    public class ServicesMainViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToTransientServicePage { get; private set; }

        public DelegateCommand GoToSingletonServicePage { get; private set; }

        public DelegateCommand GoToPreviousPage { get; private set; }

        public ServicesMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToTransientServicePage = new DelegateCommand(NavigateToTransientServicePage);
            GoToSingletonServicePage = new DelegateCommand(NavigateToSingletonServicePage);
            GoToPreviousPage = new DelegateCommand(BackToPreviousPage);
        }

        async void NavigateToTransientServicePage() =>
            await _navigationService.NavigateAsync("TransientService");

        async void NavigateToSingletonServicePage() =>
            await _navigationService.NavigateAsync("SingletonService");

        async void BackToPreviousPage() =>
            await _navigationService.NavigateAsync("/HomePageView");
    }
}
