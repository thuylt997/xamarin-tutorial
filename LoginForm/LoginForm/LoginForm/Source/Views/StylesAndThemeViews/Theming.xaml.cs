using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.StylesAndThemeViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theming : ContentPage
    {
        public Theming()
        {
            InitializeComponent();
        }

        async void OnThemeToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ThemeSelectionPage()));
        }
    }
}