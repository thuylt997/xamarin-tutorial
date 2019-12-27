using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.DataBindingTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlternativeCodeBinding : ContentPage
    {
        public AlternativeCodeBinding()
        {
            InitializeComponent();

            label.SetBinding(Label.ScaleProperty, new Binding("Value", source: slider));
        }
    }
}