using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginForm.Source.Views.CommandInterfaceTabs.ViewModel
{
    public class DecimalKeypadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string entryTextDefault = "0";

        public ICommand ClearCommand { get; private set; }

        public ICommand BackspaceCommand { get; private set; }

        public ICommand DigitCommand { get; private set; }

        public string EntryTextDefault
        {
            get => entryTextDefault;
            private set
            {
                if (entryTextDefault != value)
                {
                    entryTextDefault = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EntryTextDefault"));
                }
            }
        }

        public DecimalKeypadViewModel()
        {
            ClearCommand = new Command(
                execute: () =>
                {
                    EntryTextDefault = "0";
                    RefreshCanExecutes();
                }
            );

            BackspaceCommand = new Command(
                execute: () =>
                {
                    EntryTextDefault = EntryTextDefault.Substring(0, EntryTextDefault.Length - 1);

                    if (EntryTextDefault == "")
                    {
                        EntryTextDefault = "0";
                    }

                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return EntryTextDefault.Length > 1 || EntryTextDefault != "0";
                }
            );

            DigitCommand = new Command<string>(
                execute: (string args) =>
                {
                    EntryTextDefault += args;

                    if (EntryTextDefault.StartsWith("0") && !EntryTextDefault.StartsWith("0."))
                    {
                        EntryTextDefault = EntryTextDefault.Substring(1);
                    }

                    RefreshCanExecutes();
                },
                canExecute: (string args) =>
                {
                    return !(args == "." && EntryTextDefault.Contains("."));
                }
            );
        }

        void RefreshCanExecutes()
        {
            (BackspaceCommand as Command).ChangeCanExecute();
            ((Command)DigitCommand).ChangeCanExecute();
        }
    }
}
