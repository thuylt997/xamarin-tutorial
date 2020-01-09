using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T backingStore,
                                              T value,
                                              [CallerMemberName] string propertyName = null,
                                              Action onChanged = null,
                                              Func<T, T, bool> validateValue = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            if (validateValue != null && !validateValue(backingStore, value))
            {
                return false;
            }

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
