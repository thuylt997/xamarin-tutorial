using LoginForm.Source.Views.BehaviorsTabViews.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginForm.Source.Views.BehaviorsTabViews
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; private set; }

        public ICommand OutputAgeCommand { get; private set; }

        public string SelectedItemText { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person("Huy", 1994),
                new Person("Phuoc", 1995),
                new Person("Thuy", 1997),
                new Person("Toan", 1997),
                new Person("Dat", 1997),
                new Person("Nhi", 1998)
            };

            OutputAgeCommand = new Command<Person>(OutputAge);
        }

        void OutputAge(Person person)
        {
            SelectedItemText = string.Format("{0} was born in {1}.", person.Name, person.Age);
            OnPropertyChanged("SelectedItemText");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;

            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
