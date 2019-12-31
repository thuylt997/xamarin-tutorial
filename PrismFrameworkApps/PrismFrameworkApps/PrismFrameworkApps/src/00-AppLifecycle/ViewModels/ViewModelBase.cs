using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._00_AppLifecycle.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public DelegateCommand BackToMenuCommand { get; }

        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;

            BackToMenuCommand = new DelegateCommand(OnBackToMenuCommandExecuted);
        }

        async void OnBackToMenuCommandExecuted()
        {
            var result = await NavigationService.NavigateAsync("/HomePageView");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void Destroy()
        {

        }
    }
}
