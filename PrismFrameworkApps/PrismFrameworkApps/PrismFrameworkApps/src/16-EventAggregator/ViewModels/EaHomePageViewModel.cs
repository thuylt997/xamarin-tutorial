using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using PrismFrameworkApps.src._16_EventAggregator.Models;
using PrismFrameworkApps.src._16_EventAggregator.Navigation;
using System.Windows.Input;

namespace PrismFrameworkApps.src._16_EventAggregator.ViewModels
{
    public class EaHomePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ICommand EntryCommand { get; }
        public ICommand GoBackCommand { get; }

        private bool isFun;

        public bool IsFun
        {
            get => isFun;
            set => SetProperty(ref isFun, value);
        }

        public EaHomePageViewModel(INavigationService navigationService,
                                   IEventAggregator eventAggregator,
                                   IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "Your feedback (read only)";

            _eventAggregator.GetEvent<IsFunChangedEvent>().Subscribe(IsFunChanged);

            EntryCommand = new DelegateCommand(
                () =>
                {
                    _navigationService.NavigateAsync(Navigate.DataEntry);
                }
            );

            GoBackCommand = new DelegateCommand(
                () =>
                {
                    _navigationService.GoBackAsync();
                }
            );
        }

        public void IsFunChanged(bool isFun) => IsFun = isFun;

        public override void Destroy() =>
            _eventAggregator.GetEvent<IsFunChangedEvent>().Unsubscribe(IsFunChanged);
    }
}
