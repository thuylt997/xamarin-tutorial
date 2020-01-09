using Xamarin.Essentials;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class BatteryViewModel : BaseViewModel
    {
        public double Level => Battery.ChargeLevel;

        public BatteryState State => Battery.State;

        public BatteryPowerSource PowerSource => Battery.PowerSource;

        public EnergySaverStatus EnergySaverStatus => Battery.EnergySaverStatus;

        public override void OnAppearing()
        {
            base.OnAppearing();

            Battery.BatteryInfoChanged += OnBatteryInfoChanged;
            Battery.EnergySaverStatusChanged += OnEnergySaverStatusChanged;
        }

        public override void OnDisappearing()
        {
            Battery.BatteryInfoChanged -= OnBatteryInfoChanged;
            Battery.EnergySaverStatusChanged -= OnEnergySaverStatusChanged;

            base.OnDisappearing();
        }

        private void OnEnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e) =>
            OnPropertyChanged(nameof(EnergySaverStatus));

        private void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(State));
            OnPropertyChanged(nameof(PowerSource));
        }
    }
}
