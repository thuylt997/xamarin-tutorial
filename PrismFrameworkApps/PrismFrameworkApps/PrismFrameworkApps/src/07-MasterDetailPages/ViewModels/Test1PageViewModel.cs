using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace PrismFrameworkApps.src._07_MasterDetailPages.ViewModels
{
    public class Test1PageViewModel : BindableBase, IActiveAware
    {
        INavigationService _navigationService;

        private bool isActive;

        public DelegateCommand LoginCommand { get; set; }

        public event EventHandler IsActiveChanged;

        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value, RaiseIsActiveChanged);
        }

        protected virtual void RaiseIsActiveChanged() =>
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

        public Test1PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new DelegateCommand(LoginCommandExecuted);
        }

        async void LoginCommandExecuted() =>
            await _navigationService.NavigateAsync(
                new Uri($"HomePage", UriKind.Relative),
                null,
                false
            );
    }
}
