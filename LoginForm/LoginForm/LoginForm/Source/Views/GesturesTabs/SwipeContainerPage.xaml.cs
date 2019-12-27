using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.GesturesTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeContainerPage : ContentPage
    {
        public SwipeContainerPage() => InitializeComponent();

        void OnSwiped(object sender, SwipedEventArgs e) =>
            label.Text = $"You swiped: {e.Direction.ToString()}";
    }
}