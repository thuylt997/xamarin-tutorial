using Prism.Navigation;

namespace PrismFrameworkApps.src._00_AppLifecycle.ViewModels
{
    public class AppLifecycleMainPageViewModel : ViewModelBase
    {
        public AppLifecycleMainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Application Lifecycle Main Page";
        }
    }
}
