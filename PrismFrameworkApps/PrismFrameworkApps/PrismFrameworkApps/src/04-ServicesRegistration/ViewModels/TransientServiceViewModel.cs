using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismFrameworkApps.src._04_ServicesRegistration.Interfaces;

namespace PrismFrameworkApps.src._04_ServicesRegistration.ViewModels
{
    public class TransientServiceViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private int numberValue;

        public DelegateCommand GoBackCommand { get; private set; }

        public int NumberValue
        {
            get => numberValue;
            set => SetProperty(ref numberValue, value);
        }

        public TransientServiceViewModel(INavigationService navigationService, IExampleAlphaService exampleAlphaService)
        {
            _navigationService = navigationService;

            NumberValue = exampleAlphaService.NumberValue;

            GoBackCommand = new DelegateCommand(BackToPreviousPage);
        }

        async void BackToPreviousPage() =>
            await _navigationService.GoBackAsync();
    }
}
