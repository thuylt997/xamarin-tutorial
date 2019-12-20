using LoginForm.Source.Views.CssStylingXFormsAppDir.Models;
using LoginForm.Source.Views.CssStylingXFormsAppDir.ViewModels;
using LoginForm.Source.Views.CssStylingXFormsAppDir.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CssStylingXFormsApp : ContentPage
    {
        public CssStylingXFormsApp()
        {
            InitializeComponent();

            BindingContext = new ItemViewModel();
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e) => ((ListView)sender).SelectedItem = null;

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as Monkey;

            if (item != null)
            {
                var page = new Detail();

                page.BindingContext = item;

                await Navigation.PushAsync(page);
            }
        }
    }
}