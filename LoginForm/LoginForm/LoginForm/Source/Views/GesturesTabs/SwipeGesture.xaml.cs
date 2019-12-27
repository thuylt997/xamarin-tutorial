using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.GesturesTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeGesture : ContentPage
    {
        public SwipeGesture() => InitializeComponent();

        void OnSwiped(object sender, SwipedEventArgs e) =>
            label.Text = $"You swiped: {e.Direction.ToString()}";
    }
}