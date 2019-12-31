using Prism.AppModel;
using Prism.Navigation;

namespace PrismFrameworkApps.src._00_AppLifecycle.ViewModels
{
    public class ViewModelExample : ViewModelBase, IApplicationLifecycleAware
    {
        protected INavigationService _navigationService { get; private set; }

        public ViewModelExample(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnResume()
        {
            // Restore the state of your ViewModel.
        }

        public void OnSleep()
        {
            // Save the state of your ViewModel.
        }
    }
}
