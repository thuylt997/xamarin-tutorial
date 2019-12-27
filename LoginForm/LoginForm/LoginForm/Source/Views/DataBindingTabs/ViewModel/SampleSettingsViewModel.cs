using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.ViewModel
{
    public class SampleSettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string name;
        DateTime birthDate;
        bool codesInCSharp;
        double numberOfCopies;
        NamedColor backgroundNamedColor;

        public SampleSettingsViewModel(IDictionary<string, object> dictionary)
        {
            Name = GetDictionaryEntry<string>(dictionary, "Name");
            BirthDate = GetDictionaryEntry(dictionary, "BirthDate", new DateTime(1980, 1, 1));
            CodeInCSharp = GetDictionaryEntry<bool>(dictionary, "CodeInCSharp");
            NumberOfCopies = GetDictionaryEntry(dictionary, "NumberOfCopies", 1.0);
            BackgroundNamedColor = NamedColor.Find(GetDictionaryEntry(dictionary, "BackgroundNamedColor", "White"));
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => SetProperty(ref birthDate, value);
        }

        public bool CodeInCSharp
        {
            get => codesInCSharp;
            set => SetProperty(ref codesInCSharp, value);
        }

        public double NumberOfCopies
        {
            get => numberOfCopies;
            set => SetProperty(ref numberOfCopies, value);
        }

        public NamedColor BackgroundNamedColor
        {
            get => backgroundNamedColor;
            set
            {
                if (SetProperty(ref backgroundNamedColor, value))
                {
                    OnPropertyChanged("BackgroundColor");
                }
            }
        }

        public Color BackgroundColor => BackgroundNamedColor?.Color ?? Color.White;

        public void SaveState(IDictionary<string, object> dictionary)
        {
            dictionary["Name"] = Name;
            dictionary["BirthDate"] = BirthDate;
            dictionary["CodeInCSharp"] = CodeInCSharp;
            dictionary["NumberOfCopies"] = NumberOfCopies;
            dictionary["BackgroundNamedColor"] = BackgroundNamedColor.Name;
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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        T GetDictionaryEntry<T>(IDictionary<string, object> dictionary, string key, T defaultValue = default(T)) =>
            dictionary.ContainsKey(key) ? (T)dictionary[key] : defaultValue;
    }
}
