using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginForm.Source.Views.GesturesTabs.ViewModel
{
    public class TapViewModel : INotifyPropertyChanged
    {
        // INotifyPropertyChanged event handler
        public event PropertyChangedEventHandler PropertyChanged;

        ICommand tapCommand;
        int taps = 0;
        string numberOfTapsTapped;

        // START - Creating Accessors Get and Set
        public ICommand TapCommand
        {
            get => tapCommand;
        }

        public string NumberOfTapsTapped
        {
            get => numberOfTapsTapped;
            set
            {
                if (numberOfTapsTapped == value)
                {
                    return;
                }

                numberOfTapsTapped = value;
                OnPropertyChanged();
            }
        }
        //END - Creating Accessors Get and Set

        // Constructor - Configure the TapCommand with a method
        public TapViewModel() => tapCommand = new Command(OnTapped);

        // OnTapped() - handle event when tap gesture has been recognizer
        private void OnTapped(object obj)
        {
            taps++;
            Debug.WriteLine("Parameter: " + obj);
            NumberOfTapsTapped = String.Format("{0} tap{1} so far!", taps, taps == 1 ? "" : "s");
        }

        // INotifyPropertyChanged method, invoke when the value of the property changed
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
