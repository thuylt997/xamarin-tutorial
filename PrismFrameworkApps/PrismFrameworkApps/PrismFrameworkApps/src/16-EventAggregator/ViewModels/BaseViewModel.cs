using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._16_EventAggregator.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IInitialize, IDestructible
    {
        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
