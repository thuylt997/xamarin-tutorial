using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using PrismFrameworkApps.src._16_EventAggregator.Models;
using System.Windows.Input;

namespace PrismFrameworkApps.src._16_EventAggregator.ViewModels
{
    public class DataEntryPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        private bool isFun;

        public bool IsFun
        {
            get => isFun;
            set => SetProperty(
                ref isFun,
                value,
                () =>
                {
                    _eventAggregator.GetEvent<IsFunChangedEvent>().Publish(value);
                }
            );
        }

        public ICommand SubmitCommand { get; }

        public DataEntryPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "So what do you think?";

            SubmitCommand = new DelegateCommand(
                () =>
                {
                    _navigationService.GoBackAsync();
                }
            );
        }
    }
}
