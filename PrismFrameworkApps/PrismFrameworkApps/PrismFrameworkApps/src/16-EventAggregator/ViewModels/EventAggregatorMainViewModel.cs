using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using PrismFrameworkApps.src._16_EventAggregator.Models;
using PrismFrameworkApps.src._16_EventAggregator.Navigation;
using System.Windows.Input;

namespace PrismFrameworkApps.src._16_EventAggregator.ViewModels
{
    public class EventAggregatorMainViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ICommand LocalCommand { get; }
        public ICommand NativeCommand { get; }

        public EventAggregatorMainViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "Prism.Forms Event Aggregator";

            LocalCommand = new DelegateCommand(
                () =>
                {
                    _navigationService.NavigateAsync(Navigate.Home);
                }
            );

            NativeCommand = new DelegateCommand(
                () =>
                {
                    _eventAggregator.GetEvent<NativeEvent>()
                                    .Publish(
                                        new NativeEventArgs("Xamarin.Forms")
                                    );
                }
            );
        }
    }
}
