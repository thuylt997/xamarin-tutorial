using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.DataBindingTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicCodeBinding : ContentPage
    {
        public BasicCodeBinding()
        {
            InitializeComponent();

            label.BindingContext = slider; // Binding source
            label.SetBinding(Label.RotationProperty, "Value"); // Binding target
        }
    }
}