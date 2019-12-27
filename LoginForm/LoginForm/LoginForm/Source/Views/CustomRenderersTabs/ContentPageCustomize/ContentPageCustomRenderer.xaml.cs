using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.CustomRenderersTabs.ContentPageCustomize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentPageCustomRenderer : ContentPage
    {
        public ContentPageCustomRenderer() => InitializeComponent();

        async void OnTakePhotoButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CameraPage());
        }
    }
}