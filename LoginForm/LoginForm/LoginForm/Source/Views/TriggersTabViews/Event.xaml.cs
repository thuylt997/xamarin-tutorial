using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.TriggersTabViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Event : ContentPage
    {
        public Event()
        {
            InitializeComponent();
        }

        async void OnDoThisClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Do this", "Alert displays as well as TriggerAction", "Cool");
        }

        async void OnDoThatClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Do that", "Alert displays as well as TriggerAction", "Cool");
        }
    }
}