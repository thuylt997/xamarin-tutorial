using Newtonsoft.Json;
using PrismFrameworkApps.src._13_RefitRestApi.Models;
using PrismFrameworkApps.src._13_RefitRestApi.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._14_AdvancedRestApi.ViewModels
{
    public class RestApiMainPageViewModel : BaseViewModel
    {
        private ObservableCollection<MakeUp> makeUpsCollection;
        private ObservableCollection<News> newsCollection;

        public ObservableCollection<MakeUp> MakeUpsCollection
        {
            get => makeUpsCollection;
            set
            {
                makeUpsCollection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<News> NewsCollection
        {
            get => newsCollection;
            set
            {
                newsCollection = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetDataCommand { get; set; }
        public ICommand GetTimeLineDataCommand { get; set; }

        public string Title { get; set; }

        public RestApiMainPageViewModel()
        {
            Title = "REST APIs Main Page";

            GetDataCommand = new Command(
                // The parameter of RunSafe method is a task.
                async () => await RunSafe(GetData())
            );

            GetTimeLineDataCommand = new Command(
                async () => await RunSafe(GetTimeLineData())
            );
        }

        async Task GetTimeLineData()
        {
            var timelineResponse = await apiManager.GetNews();

            if (timelineResponse.IsSuccessStatusCode)
            {
                var response = await timelineResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(
                    () => JsonConvert.DeserializeObject<RootNews>(response)
                );

                NewsCollection = new ObservableCollection<News>(json.Data.News);
            }
            else
            {
                await userDialogs.AlertAsync("Unable to get data", "Error", "OK");
            }
        }

        async Task GetData()
        {
            var makeUpsResponse = await apiManager.GetMakeUps("maybelline");

            if (makeUpsResponse.IsSuccessStatusCode)
            {
                // If the request was Success parse the response json into a List<MakeUp>
                var response = await makeUpsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(
                    () => JsonConvert.DeserializeObject<List<MakeUp>>(response)
                );

                MakeUpsCollection = new ObservableCollection<MakeUp>(json);
            }
            else
            {
                await userDialogs.AlertAsync("Unable to get data", "Error", "OK");
            }
        }
    }
}
