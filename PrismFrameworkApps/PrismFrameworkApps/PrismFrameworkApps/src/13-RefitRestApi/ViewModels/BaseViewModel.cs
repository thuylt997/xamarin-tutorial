using Acr.UserDialogs;
using PrismFrameworkApps.src._13_RefitRestApi.Services;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PrismFrameworkApps.src._13_RefitRestApi.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IUserDialogs userDialogs = UserDialogs.Instance;

        public IApiManager apiManager;

        // Instantiate the API Service and passing API URL.
        IApiService<IMakeUpApi> makeUpApi = new ApiService<IMakeUpApi>(Config.ApiUrl);
        IApiService<IRedditApi> redditApi = new ApiService<IRedditApi>(Config.RedditApiUrl);

        public bool isBusy { get; set; }

        // Instantiate the API Manager padding the API Service.
        public BaseViewModel() =>
            apiManager = new ApiManager(makeUpApi, redditApi);

        public async Task RunSafe(Task task, bool showLoading = true, string loadingMessage = null)
        {
            try
            {
                // All the requests will be handle for this method to prevent any crash
                if (isBusy)
                {
                    return;
                }

                isBusy = true;

                // Show Loading by default in all the requests, but can be set to false if you want
                if (showLoading)
                {
                    UserDialogs.Instance.ShowLoading(loadingMessage ?? "Loading");
                }

                await task;
            }
            catch (Exception error)
            {
                // Handling exception
                isBusy = false;

                UserDialogs.Instance.HideLoading();

                Debug.WriteLine(error.ToString());

                await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection", "OK");
            }
            finally
            {
                isBusy = false;

                if (showLoading)
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
