using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.PageCollection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingAppointmentsPage : ContentPage
    {
        public UpcomingAppointmentsPage()
        {
            InitializeComponent();
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}