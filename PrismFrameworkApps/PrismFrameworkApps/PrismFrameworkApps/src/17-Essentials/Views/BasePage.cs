using PrismFrameworkApps.src._17_Essentials.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.Views
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            NavigationPage.SetBackButtonTitle(this, "Back");

            if (Device.Idiom == TargetIdiom.Watch)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SetupBinding(BindingContext);
        }

        protected void SetupBinding(object bindingContext)
        {
            if (bindingContext is BaseViewModel vm)
            {
                vm.DoDisplayAlert += OnDisplayAlert;
                vm.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            TearDownBinding(BindingContext);

            base.OnDisappearing();
        }

        protected void TearDownBinding(object bindingContext)
        {
            if (bindingContext is BaseViewModel vm)
            {
                vm.OnDisappearing();
                vm.DoDisplayAlert -= OnDisplayAlert;
            }
        }

        private Task OnDisplayAlert(string message) =>
            DisplayAlert(Title, message, "OK");
    }
}
