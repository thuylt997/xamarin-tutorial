using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.SliderTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicSlider : ContentPage
    {
        public BasicSlider() => InitializeComponent();

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;

            rotatingLabel.Rotation = value;
            displayLabel.Text = String.Format("The Slider value is {0}", value);
        }
    }
}