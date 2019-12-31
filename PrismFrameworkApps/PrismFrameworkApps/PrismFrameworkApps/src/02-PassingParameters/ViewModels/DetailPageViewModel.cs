using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._02_PassingParameters.ViewModels
{
    // You can implement INavigationAware on either the View or ViewModel.
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string detailPageTitle;

        private DelegateCommand navigateCommand;

        public string DetailPageTitle
        {
            get => detailPageTitle;
            set => SetProperty(ref detailPageTitle, value);
        }

        public DetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            DetailPageTitle = "Detail Page";
        }

        public DelegateCommand NavigateCommand =>
            navigateCommand ?? (navigateCommand = new DelegateCommand(NavigateCommandExecuted));

        async void NavigateCommandExecuted() =>
            await _navigationService.GoBackAsync();

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters) =>
            DetailPageTitle = parameters.GetValue<string>("greeting");
    }
}
