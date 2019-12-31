using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._02_PassingParameters.ViewModels
{
    public class PassParamMainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private string mainPageTitle;

        private DelegateCommand navigateCommand;

        public string MainPageTitle
        {
            get => mainPageTitle;
            set => SetProperty(ref mainPageTitle, value);
        }

        public PassParamMainPageViewModel(INavigationService navigationService)
        {
            MainPageTitle = "Passing Parameters Main Page";

            _navigationService = navigationService;
        }

        public DelegateCommand NavigateCommand =>
            navigateCommand ?? (navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        async void ExecuteNavigateCommand()
        {
            var navigationParameter1 = new NavigationParameters();

            navigationParameter1.Add("greeting", "Hello Detail Page from Main Page");

            //var navigationParameter2 = new NavigationParameters("id=1&name=tuongthuy&color=pink");

            //await _navigationService.NavigateAsync("DetailPage?id=tuongthuy&color=pink", navigationParameter1);
            await _navigationService.NavigateAsync("DetailPage", navigationParameter1);
        }
    }
}
