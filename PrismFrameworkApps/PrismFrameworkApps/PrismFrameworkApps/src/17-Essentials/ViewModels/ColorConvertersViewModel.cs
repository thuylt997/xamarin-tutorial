using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class ColorConvertersViewModel : BaseViewModel
    {
        int alpha = 100;
        int saturation = 100;
        int hue = 360;
        int luminosity = 100;
        string hex = "#3498db";

        public int Alpha
        {
            get => alpha;
            set
            {
                SetProperty(ref alpha, value);
                SetColor();
            }
        }

        public int Saturation
        {
            get => saturation;
            set
            {
                SetProperty(ref saturation, value);
                SetColor();
            }
        }

        public int Hue
        {
            get => hue;
            set
            {
                SetProperty(ref hue, value);
                SetColor();
            }
        }

        public int Luminosity
        {
            get => luminosity;
            set
            {
                SetProperty(ref luminosity, value);
                SetColor();
            }
        }

        public string Hex
        {
            get => hex;
            set
            {
                SetProperty(ref hex, value);
                SetColor();
            }
        }

        public Color RegularColor { get; set; }
        public Color AlphaColor { get; set; }
        public Color SaturationColor { get; set; }
        public Color HueColor { get; set; }
        public Color LuminosityColor { get; set; }
        public Color ComplementColor { get; set; }

        private void SetColor()
        {
            try
            {
                var color = ColorConverters.FromHex(Hex);

                RegularColor = color;
                AlphaColor = color.WithAlpha(Alpha);
                SaturationColor = color.WithSaturation(Saturation);
                HueColor = color.WithHue(Hue);
                LuminosityColor = color.WithLuminosity(Luminosity);
                //ComplementColor = color.GetComplementary();

                OnPropertyChanged(nameof(RegularColor));
                OnPropertyChanged(nameof(AlphaColor));
                OnPropertyChanged(nameof(SaturationColor));
                OnPropertyChanged(nameof(HueColor));
                OnPropertyChanged(nameof(LuminosityColor));
                OnPropertyChanged(nameof(ComplementColor));
            }
            catch (Exception)
            {

            }
        }
    }
}
