using Prism.Events;
using PrismFrameworkApps.src._08_NavigationPages.Events;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._08_NavigationPages.Views
{
    public class CustomNavigationPage : NavigationPage
    {
        IEventAggregator _eventAggregator;

        public CustomNavigationPage(IEventAggregator eventAggregator) =>
            _eventAggregator = eventAggregator;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _eventAggregator.GetEvent<UpdateNavigationBarEvent>().Subscribe(UpdateColor);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _eventAggregator.GetEvent<UpdateNavigationBarEvent>().Unsubscribe(UpdateColor);
        }

        void UpdateColor(bool isShowingTheLoging) =>
            BarBackgroundColor = (isShowingTheLoging) ? Color.Black : Color.Red;
    }
}
