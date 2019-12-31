using Prism.Navigation;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFrameworkApps.src._02_PassingParameters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // You can implement INavigationAware on either the View or ViewModel
    public partial class DetailPage : ContentPage, INavigationAware
    {
        public DetailPage() => InitializeComponent();

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}