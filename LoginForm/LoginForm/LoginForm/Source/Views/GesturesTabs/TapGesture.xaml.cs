using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.GesturesTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TapGesture : ContentPage
    {
        int count = 0;

        public TapGesture() => InitializeComponent();

        public void OnTapGestureRecognizerTapped(object sender, TappedEventArgs e)
        {
            count++;

            var imageSender = (Image)sender;

            // watch the monkey go from color to black & white!
            if (count % 2 == 0)
            {
                imageSender.Source = "tapped.jpg";
            }
            else
            {
                imageSender.Source = "tapped_bw.jpg";
            }
        }
    }
}