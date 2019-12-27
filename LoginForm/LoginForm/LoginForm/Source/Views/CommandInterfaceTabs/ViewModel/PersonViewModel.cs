using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoginForm.Source.Views.CommandInterfaceTabs.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string name;
        double age;
        string skills;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public double Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        public string Skills
        {
            get => skills;
            set => SetProperty(ref skills, value);
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString() =>
            String.Format(Name + " is " + Age + " years old");
    }
}
