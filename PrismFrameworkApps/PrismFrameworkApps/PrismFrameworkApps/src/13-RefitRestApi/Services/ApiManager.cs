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

namespace PrismFrameworkApps.src._13_RefitRestApi.Services
{
    // Create API Manager
    public class ApiManager : IApiManager
    {
        IApiService<IMakeUpApi> makeUpApi;
        IApiService<IRedditApi> redditApi;

        // Show a Toast if there is no internet connection
        IUserDialogs userDialogs = UserDialogs.Instance;

        // Connection Handler - handle the connection changes
        IConnectivity connectivity = CrossConnectivity.Current;

        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();

        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }

        // Receive the IApiService in the constructor
        public ApiManager(IApiService<IMakeUpApi> _makeUpApi, IApiService<IRedditApi> _redditApi)
        {
            makeUpApi = _makeUpApi;
            redditApi = _redditApi;

            IsConnected = connectivity.IsConnected;

            connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.IsConnected;

            // START - If there is not internet connection, cancel all the running requests
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
            // END - If there is not internet connection, cancel all the running requests
        }

        /**
         * RemoteRequestAsync method - add the task to the running tasks list,
         * so we can cancel it if there is any issue.
         */
        public async Task<HttpResponseMessage> GetMakeUps(string brand)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var task = RemoteRequestAsync(makeUpApi.GetApi(Priority.UserInitiated).GetMakeUpss(brand));

            runningTasks.Add(task.Id, cancellationTokenSource);

            return await task;
        }

        public async Task<HttpResponseMessage> GetNews()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var task = RemoteRequestAsync(redditApi.GetApi(Priority.UserInitiated).GetNews(cancellationTokenSource.Token));

            runningTasks.Add(task.Id, cancellationTokenSource);

            return await task;
        }

        protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task) where TData : HttpResponseMessage, new()
        {
            TData data = new TData();

            // START - If there is not internet connection, show a Toast showing it
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
            // END - If there is not internet connection, show a Toast showing it

            // Handle Web Exception
            data = await Policy.Handle<WebException>()
                               .Or<ApiException>()
                               .Or<TaskCanceledException>()
                               .WaitAndRetryAsync( // Retry if there was an issue
                                    retryCount: 1,
                                    sleepDurationProvider: (retryAttempt) =>
                                        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                )
                               .ExecuteAsync(
                                    async () =>
                                    {
                                        var result = await task;

                                        // Handling the logic here if the token expired 
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
