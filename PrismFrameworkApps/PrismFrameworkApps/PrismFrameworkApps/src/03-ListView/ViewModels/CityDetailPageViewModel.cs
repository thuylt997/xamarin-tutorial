using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._03_ListView.ViewModels
{
    public class CityDetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string cityNameTitle;

        public string CityNameTitle
        {
            get => cityNameTitle;
            set => SetProperty(ref cityNameTitle, value);
        }

        public DelegateCommand BackToMenuCommand { get; }

        public CityDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            BackToMenuCommand = new DelegateCommand(
                async () => await _navigationService.NavigateAsync("/NavigationPage/ListSample")
            );
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters) =>
            CityNameTitle = parameters.GetValue<string>("citynamekey");
    }
}
