using System.ComponentModel;
using Xamarin.Forms;

namespace LoginForm.Source.Views.SliderTabs
{
    public class HslColorViewModel : INotifyPropertyChanged
    {
        Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Hue
        {
            set
            {
                if (color.Hue != value)
                {
                {
                    Color = Color.FromHsla(value, color.Saturation, color.Luminosity);
                }
            }
            get => color.Hue;
        }

        public double Saturation
        {
            set
            {
                if (color.Saturation != value)
                {
                    Color = Color.FromHsla(color.Hue, value, color.Luminosity);
                }
            }
            get => color.Saturation;
        }

        public double Luminosity
        {
            set
            {
                if (color.Luminosity != value)
                {
                    Color = Color.FromHsla(color.Hue, color.Saturation, value);
                }
            }
            get => color.Luminosity;
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hue"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Saturation"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Luminosity"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
                }
            }
            get => color;
        }
    }
}
