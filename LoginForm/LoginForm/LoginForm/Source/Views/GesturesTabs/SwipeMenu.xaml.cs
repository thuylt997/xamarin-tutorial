using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.GesturesTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeMenu : ContentPage
    {
        public SwipeMenu() => InitializeComponent();

        async void OnBasicSwipeGestureButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new SwipeGesture());

        async void OnSwipeCommandButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new SwipeCommandPage());

        async void OnSwipeContainerButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new SwipeContainerPage());
    }
}