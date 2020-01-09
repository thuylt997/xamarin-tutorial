using Xamarin.Essentials;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class ConnectivityViewModel : BaseViewModel
    {
        public string NetworkAccess => Connectivity.NetworkAccess.ToString();

        public string ConnectionProfiles
        {
            get
            {
                var profiles = string.Empty;

                foreach (var item in Connectivity.ConnectionProfiles)
                {
                    profiles += "\n" + item.ToString();
                }

                return profiles;
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        public override void OnDisappearing()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;

            base.OnDisappearing();
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs eventArgs)
        {
            OnPropertyChanged(nameof(ConnectionProfile));
            OnPropertyChanged(nameof(NetworkAccess));
        }
    }
}
