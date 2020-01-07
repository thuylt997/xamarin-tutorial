using Acr.UserDialogs;
using Fusillade;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Polly;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalApp.RestApiDemo.Services
{
    public class ApiManager : IApiManager
    {
        IApiService<IMakeUpApi> makeUpApi;
        IUserDialogs userDialogs = UserDialogs.Instance;
        IConnectivity connectivity = CrossConnectivity.Current;

        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }

        public ApiManager(IApiService<IMakeUpApi> _makeUpApi)
        {
            makeUpApi = _makeUpApi;

            IsConnected = connectivity.IsConnected;

            connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            if (!e.IsConnected)
            {
                // Cancel all running tasks
                var items = runningTasks.ToList();

                foreach (var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }

        public async Task<HttpResponseMessage> GetMakeUps(string brand)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(makeUpApi.GetApi(Priority.UserInitiated).GetMakeUps(brand));

            runningTasks.Add(task.Id, cts);

            return await task;
        }

        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task) where TData : HttpResponseMessage, new()
        {
            TData data = new TData();

            if (!IsConnected)
            {
                var response = "No internet connection.";

                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(response);

                userDialogs.Toast(response, TimeSpan.FromSeconds(1));

                return data;
            }

            IsReachable = await connectivity.IsRemoteReachable(Config.ApiHostName);

            if (!IsReachable)
            {
                var response = "No internet connection.";

                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(response);

                userDialogs.Toast(response, TimeSpan.FromSeconds(1));

                return data;
            }

            // Handle Web Exception
            data = await Policy.Handle<WebException>()
                               .Or<ApiException>()
                               .Or<TaskCanceledException>()
                               .WaitAndRetryAsync(
                                    retryCount: 1,
                                    sleepDurationProvider: retryAttempt =>
                                        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                )
                               .ExecuteAsync(
                                    async () =>
                                    {
                                        var result = await task;

                                        if (result.StatusCode == HttpStatusCode.Unauthorized)
                                        {

                                        }

                                        runningTasks.Remove(task.Id);

                                        return result;
                                    }
                                );
            return data;
        }
    }
}
