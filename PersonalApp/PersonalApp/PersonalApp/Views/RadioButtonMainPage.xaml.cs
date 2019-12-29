using PersonalApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioButtonMainPage : ContentPage
    {
        public RadioButtonMainPage()
        {
            InitializeComponent();

            //CreateRadioButton();
            //RadioButtonBinding();
        }

        void CreateRadioButton()
        {
            CustomRadioButton radioButton = new CustomRadioButton();

            radioButton.IsChecked = false;
            radioButton.IsVisible = true;
            radioButton.Title = "Japan";
            radioButton.BorderImageSource = "radioborder";
            radioButton.CheckedBackgroundImageSource = "radiocheckedbg";
            radioButton.CheckMarkImageSource = "radiocheckmark";

            stackPanel.Children.Add(radioButton);
        }

        void RadioButtonBinding()
        {
            CountryViewModel country = new CountryViewModel();

            country.Name = "Singapore";
            country.IsSelected = false;
            country.IsVisible = true;

            CustomRadioButton radioButton = new CustomRadioButton();

            radioButton.BindingContext = country;
            radioButton.SetBinding(CustomRadioButton.IsCheckedProperty, "IsSelected", BindingMode.TwoWay);
            radioButton.SetBinding(IsVisibleProperty, "IsVisible");
            radioButton.SetBinding(CustomRadioButton.TitleProperty, "Name");
            radioButton.BorderImageSource = "radioborder";
            radioButton.CheckedBackgroundImageSource = "radiocheckedbg";
            radioButton.CheckMarkImageSource = "radiocheckmark";

            stackPanel.Children.Add(radioButton);
        }
    }
}