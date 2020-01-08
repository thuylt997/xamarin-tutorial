using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFrameworkApps.src._15_MessagingCenter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingCenterMain : ContentPage
    {
        public MessagingCenterMain()
        {
            InitializeComponent();

            // Subscribe to a message (which the ViewModel has also subscribed to) to display an alert
            MessagingCenter.Subscribe<MessagingCenterMain, string>(
                this,
                "Hi",
                async (sender, args) =>
                {
                    await DisplayAlert(
                        "Message received",
                        "args = " + args,
                        "OK"
                    );
                }
            );
        }

        void OnSayHiButtonClicked(object sender, EventArgs e) =>
            MessagingCenter.Send<MessagingCenterMain>(this, "Hi");

        void OnSayHiToThuyButtonClicked(object sender, EventArgs e) =>
            MessagingCenter.Send<MessagingCenterMain, string>(this, "Hi", "Thuy");

        async void OnUnsubscribeButtonClicked(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<MessagingCenterMain, string>(this, "Hi");

            await DisplayAlert(
                "Unsubcribed",
                "This page has stopped listening, so no more alerts. However, the ViewModel is still receiving messages",
                "OK"
            );
        }
    }
}