using System;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class GeolocationViewModel : BaseViewModel
    {
        string notAvailable = "not available";
        string lastLocation;
        string currentLocation;
        int accuracy = (int)GeolocationAccuracy.Default;
        CancellationTokenSource cancellationTokenSource;

        public GeolocationViewModel()
        {
            GetLastLocationCommand = new Command(OnGetLastLocation);
            GetCurrentLocationCommand = new Command(OnGetCurrentLocation);
        }

        public ICommand GetLastLocationCommand { get; }

        public ICommand GetCurrentLocationCommand { get; }

        public string LastLocation
        {
            get => lastLocation;
            set => SetProperty(ref lastLocation, value);
        }

        public string CurrentLocation
        {
            get => currentLocation;
            set => SetProperty(ref currentLocation, value);
        }

        public string[] Accuracies => Enum.GetNames(typeof(GeolocationAccuracy));

        public int Accuracy
        {
            get => accuracy;
            set => SetProperty(ref accuracy, value);
        }

        async void OnGetLastLocation()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                LastLocation = FormatLocation(location);
            }
            catch (Exception error)
            {
                LastLocation = FormatLocation(null, error);
            }

            IsBusy = false;
        }

        async void OnGetCurrentLocation()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                var request = new GeolocationRequest((GeolocationAccuracy)Accuracy);

                cancellationTokenSource = new CancellationTokenSource();

                var location = await Geolocation.GetLocationAsync(request, cancellationTokenSource.Token);

                CurrentLocation = FormatLocation(location);
            }
            catch (Exception error)
            {
                CurrentLocation = FormatLocation(null, error);
            }
            finally
            {
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }

            IsBusy = false;
        }

        string FormatLocation(Location location, Exception error = null)
        {
            if (location == null)
            {
                return $"Unable to detect location. Exception: {error?.Message ?? string.Empty}";
            }

            return
                $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n" +
                $"Accuracy: {location.Accuracy}\n" +
                $"Altitude: {(location.Altitude.HasValue ? location.Altitude.Value.ToString() : notAvailable)}\n" +
                $"Heading: {(location.Course.HasValue ? location.Course.Value.ToString() : notAvailable)}\n" +
                $"Speed: {(location.Speed.HasValue ? location.Speed.Value.ToString() : notAvailable)}\n" +
                $"Date (UTC): {location.Timestamp:d}\n" +
                $"Time (UTC): {location.Timestamp:T}\n" +
                $"Moking Provider: {location.IsFromMockProvider}";
        }

        public override void OnDisappearing()
        {
            if (IsBusy)
            {
                if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
                {
                    cancellationTokenSource.Cancel();
                }
            }

            base.OnDisappearing();
        }
    }
}
