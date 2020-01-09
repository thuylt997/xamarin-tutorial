using System;
using System.Threading.Tasks;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy,
                               value,
                               onChanged: () =>
                               {
                                   OnPropertyChanged(nameof(IsNotBusy));
                               }
                   );
        }

        public bool IsNotBusy => !IsBusy;

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        internal event Func<string, Task> DoDisplayAlert;

        public Task DisplayAlertAsync(string message) =>
            DoDisplayAlert?.Invoke(message) ?? Task.CompletedTask;
    }
}
