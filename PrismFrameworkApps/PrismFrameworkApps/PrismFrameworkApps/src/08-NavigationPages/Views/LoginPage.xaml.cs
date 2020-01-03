using Prism.Events;
using PrismFrameworkApps.src._08_NavigationPages.Events;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFrameworkApps.src._08_NavigationPages.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        IEventAggregator _eventAggregator;

        public LoginPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _eventAggregator.GetEvent<UpdateNavigationBarEvent>().Publish(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _eventAggregator.GetEvent<UpdateNavigationBarEvent>().Publish(false);
        }
    }
}