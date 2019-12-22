using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.SliderTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RgbColorSliders : ContentPage
    {
        public RgbColorSliders() => InitializeComponent();

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == redSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }

            boxView.Color = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
        }
    }
}