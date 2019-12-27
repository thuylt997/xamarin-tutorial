using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GesturesMainPage : TabbedPage
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        public GesturesMainPage() => InitializeComponent();
    }
}