using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismFrameworkApps.src._04_ServicesRegistration.Interfaces;

namespace PrismFrameworkApps.src._04_ServicesRegistration.ViewModels
{
    public class SingletonServiceViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; private set; }

        private int numberValue;

        public int NumberValue
        {
            get => numberValue;
            set => SetProperty(ref numberValue, value);
        }

        public SingletonServiceViewModel(INavigationService navigationService, IExampleBetaService exampleBetaService)
        {
            _navigationService = navigationService;

            NumberValue = exampleBetaService.NumberValue;

            GoBackCommand = new DelegateCommand(NavigateToPreviousPage);
        }

        async void NavigateToPreviousPage() =>
            await _navigationService.GoBackAsync();
    }
}
