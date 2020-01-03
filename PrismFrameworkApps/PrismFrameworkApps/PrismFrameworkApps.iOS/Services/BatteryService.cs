using PrismFrameworkApps.src._08_NavigationPages.Services;
using UIKit;

namespace PrismFrameworkApps.iOS.Services
{
    public class BatteryService : IBatteryService
    {
        public string GetBatteryStatus()
        {
            switch (UIDevice.CurrentDevice.BatteryState)
            {
                case UIDeviceBatteryState.Charging:
                    return "Charging";

                case UIDeviceBatteryState.Unplugged:
                    return "Discharging";

                case UIDeviceBatteryState.Full:
                    return "Full";

                default:
                    return "Unknown";
            }
        }
    }
}