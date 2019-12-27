using System.ComponentModel;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.ViewModel
{
    public class HslColorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Color color;
        string name;

        public double Hue
        {
            get => color.Hue;
            set
            {
                if (color.Hue != value)
                {
                    Color = Color.FromHsla(value, color.Saturation, color.Luminosity);
                }
            }
        }

        public double Saturation
        {
            get => color.Saturation;
            set
            {
                if (color.Saturation != value)
                {
                    Color = Color.FromHsla(color.Hue, value, color.Luminosity);
                }
            }
        }

        public double Luminosity
        {
            get => color.Luminosity;
            set
            {
                if (color.Luminosity != value)
                {
                    Color = Color.FromHsla(color.Hue, color.Saturation, value);
                }
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hue"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Saturation"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Luminosity"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

                    Name = NamedColor.GetNearestColorName(color);
                }
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (name != value)
                {
                    name = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    }
}
