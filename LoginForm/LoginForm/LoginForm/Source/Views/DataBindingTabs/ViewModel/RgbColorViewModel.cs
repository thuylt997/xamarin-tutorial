using System.ComponentModel;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.ViewModel
{
    public class RgbColorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Color color;
        string name;

        public double Red
        {
            get => color.R;
            set
            {
                if (color.R != value)
                {
                    Color = new Color(value, color.G, color.B);
                }
            }
        }

        public double Green
        {
            get => color.G;
            set
            {
                if (color.G != value)
                {
                    Color = new Color(color.R, value, color.B);
                }
            }
        }

        public double Blue
        {
            get => color.B;
            set
            {
                if (color.B != value)
                {
                    Color = new Color(color.R, color.G, value);
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

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Red"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Green"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Blue"));
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
