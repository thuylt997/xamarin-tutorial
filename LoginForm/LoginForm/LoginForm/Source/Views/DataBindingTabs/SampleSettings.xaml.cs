using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.DataBindingTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleSettings : ContentPage
    {
        public SampleSettings()
        {
            InitializeComponent();

            if (colorListView.SelectedItem != null)
            {
                colorListView.ScrollTo(colorListView.SelectedItem, ScrollToPosition.MakeVisible, false);
            }
        }
    }
}