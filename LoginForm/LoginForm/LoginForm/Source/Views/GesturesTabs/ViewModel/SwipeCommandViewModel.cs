using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginForm.Source.Views.GesturesTabs.ViewModel
{
    public class SwipeCommandViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SwipeCommand => new Command<string>(Swipe);

        public string SwipeDirection { get; private set; }

        public SwipeCommandViewModel() => SwipeDirection = "You swiped: ";

        void Swipe(string value)
        {
            SwipeDirection = $"You swiped: {value}";
            OnPropertyChanged("SwipeDirection");
        }

        // INotifyPropertyChanged - Notify when the value of the property changed.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
