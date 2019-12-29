using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioButtonCustomRenderer : ContentPage
    {
        public RadioButtonCustomRenderer()
        {
            InitializeComponent();

            //MyRadioButtonGroup.CheckedChanged += MyRadioGroupCheckedChanged;
        }

        void MyRadioGroupCheckedChanged(object sender, int e)
        {
            var radioButton = sender as CustomRadioButton;

            if (radioButton == null || radioButton.Id == -1)
            {
                return;
            }

            //selectedLabel.Text = radioButton.Text;
        }
    }
}