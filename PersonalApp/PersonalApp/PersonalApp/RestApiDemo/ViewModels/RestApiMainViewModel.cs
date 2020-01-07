using Newtonsoft.Json;
using PersonalApp.RestApiDemo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalApp.RestApiDemo.ViewModels
{
    public class RestApiMainViewModel : BaseViewModel
    {
        private ObservableCollection<MakeUp> makeUpsCollection;

        public ObservableCollection<MakeUp> MakeUpsCollection
        {
            get => makeUpsCollection;
            set
            {
                makeUpsCollection = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetDataCommand { get; set; }

        public string Title { get; set; }

        public RestApiMainViewModel()
        {
            Title = "REST APIs Main Page";

            GetDataCommand = new Command(
                async () => await RunSafe(GetData())
            );
        }

        async Task GetData()
        {
            var makeUpsResponse = await apiManager.GetMakeUps("maybelline");

            if (makeUpsResponse.IsSuccessStatusCode)
            {
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
