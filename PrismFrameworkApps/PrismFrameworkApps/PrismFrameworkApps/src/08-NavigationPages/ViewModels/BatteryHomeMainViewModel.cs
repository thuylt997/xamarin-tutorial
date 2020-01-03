using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismFrameworkApps.src._08_NavigationPages.Services;
using System.Windows.Input;

namespace PrismFrameworkApps.src._08_NavigationPages.ViewModels
{
    public class BatteryHomeMainViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        IPageDialogService _pageDialogService;

        IModuleManager _moduleManager;

        IBatteryService _batteryService;

        public ICommand GetBatteryStatusCommand { get; set; }

        public bool AllFieldsAreValid { get; set; } = true;

        private string username;

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public BatteryHomeMainViewModel(INavigationService navigationService,
                                        IPageDialogService pageDialogService,
                                        IModuleManager moduleManager,
                                        IBatteryService batteryService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _moduleManager = moduleManager;
            _batteryService = batteryService;

            GetBatteryStatusCommand = new DelegateCommand(GetBatteryStatusExecuted).ObservesCanExecute(() => AllFieldsAreValid);

            //GetBatteryStatusCommand = new DelegateCommand(
            //    async () => await _pageDialogService.DisplayAlertAsync(
            //        "Battery Status",
            //        _batteryService.GetBatteryStatus(),
            //        "OK"
            //    )
            //).ObservesCanExecute(
            //    () => AllFieldsAreValid
            //);
        }

        async void GetBatteryStatusExecuted()
        {
            var batteryStatus = _batteryService.GetBatteryStatus();

            await _pageDialogService.DisplayAlertAsync("Battery Status", batteryStatus, "OK");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Username"))
            {
                Username = parameters.GetValue<string>("Username");
            }
        }
    }
}
