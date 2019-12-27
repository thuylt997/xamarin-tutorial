using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginForm.Source.Views.CommandInterfaceTabs.ViewModel
{
    public class PersonCollectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        PersonViewModel personUpdate;
        bool isUpdating;

        public IList<PersonViewModel> Persons { get; } = new ObservableCollection<PersonViewModel>();

        public ICommand NewCommand { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public PersonViewModel PersonUpdate
        {
            get => personUpdate;
            set => SetProperty(ref personUpdate, value);
        }

        public bool IsUpdating
        {
            get => isUpdating;
            private set => SetProperty(ref isUpdating, value);
        }

        public PersonCollectionViewModel()
        {
            NewCommand = new Command(
                execute: () =>
                {
                    PersonUpdate = new PersonViewModel();

                    PersonUpdate.PropertyChanged += OnPersonUpdatePropertyChanged;
                    IsUpdating = true;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !IsUpdating;
                }
            );

            SubmitCommand = new Command(
                execute: () =>
                {
                    PersonUpdate.PropertyChanged -= OnPersonUpdatePropertyChanged;
                    Persons.Add(PersonUpdate);
                    PersonUpdate = null;
                    IsUpdating = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return PersonUpdate != null &&
                           PersonUpdate.Name != null &&
                           PersonUpdate.Name.Length > 1 &&
                           PersonUpdate.Age > 0;
                }
            );

            CancelCommand = new Command(
                execute: () =>
                {
                    PersonUpdate.PropertyChanged -= OnPersonUpdatePropertyChanged;
                    PersonUpdate = null;
                    IsUpdating = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return IsUpdating;
                }
            );
        }

        void OnPersonUpdatePropertyChanged(object sender, PropertyChangedEventArgs e) =>
            (SubmitCommand as Command).ChangeCanExecute();

        void RefreshCanExecutes()
        {
            (NewCommand as Command).ChangeCanExecute();
            (SubmitCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
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
    }
}
