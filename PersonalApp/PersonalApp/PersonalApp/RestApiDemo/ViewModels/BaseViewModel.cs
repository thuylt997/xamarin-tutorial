using Acr.UserDialogs;
using PersonalApp.RestApiDemo.Services;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PersonalApp.RestApiDemo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IUserDialogs userDialogs = UserDialogs.Instance;

        public IApiManager apiManager;

        IApiService<IMakeUpApi> makeUpApi = new ApiService<IMakeUpApi>(Config.ApiUrl);

        public bool isBusy { get; set; }

        public BaseViewModel() =>
            apiManager = new ApiManager(makeUpApi);

        public async Task RunSafe(Task task, bool showLoading = true, string loadingMessage = null)
        {
            try
            {
                if (isBusy)
                {
                    return;
                }

                isBusy = true;

                if (showLoading)
                {
                    UserDialogs.Instance.ShowLoading(loadingMessage ?? "Loading");
                }

                await task;
            }
            catch (Exception error)
            {
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

        protected void OnPropertyChanged([CallMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
