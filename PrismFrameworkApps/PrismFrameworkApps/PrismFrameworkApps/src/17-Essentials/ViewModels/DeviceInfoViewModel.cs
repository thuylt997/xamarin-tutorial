using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class DeviceInfoViewModel : BaseViewModel
    {
        public string Model => DeviceInfo.Model;

        public string Manufacturer => DeviceInfo.Manufacturer;

        public string Name => DeviceInfo.Name;

        public string VersionString => DeviceInfo.VersionString;

        public string Version => DeviceInfo.Version.ToString();

        public DevicePlatform Platform => DeviceInfo.Platform;

        public DeviceIdiom Idiom => DeviceInfo.Idiom;

        public DeviceType DeviceType => DeviceInfo.DeviceType;

        DisplayInfo screenMetrics;

        public DisplayInfo ScreenMetrics
        {
            get => screenMetrics;
            set => SetProperty(ref screenMetrics, value);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            DeviceDisplay.MainDisplayInfoChanged += OnScreenMetricsChanged;

            ScreenMetrics = DeviceDisplay.MainDisplayInfo;

            Task.Run(
                () =>
                {
                    var test = DeviceInfo.Idiom;
                }
            );
        }

        public override void OnDisappearing()
        {
            DeviceDisplay.MainDisplayInfoChanged -= OnScreenMetricsChanged;

            base.OnDisappearing();
        }

        private void OnScreenMetricsChanged(object sender, DisplayInfoChangedEventArgs e) =>
            ScreenMetrics = e.DisplayInfo;
    }
}
