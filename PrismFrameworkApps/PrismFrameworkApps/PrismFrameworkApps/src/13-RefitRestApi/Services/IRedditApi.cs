using Refit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrismFrameworkApps.src._13_RefitRestApi.Services
{
    [Headers("Content-Type: application/json")]
    public interface IRedditApi
    {
        [Get("/subreddit/new.json?sort=top&limit=20")]
        Task<HttpResponseMessage> GetNews(CancellationToken cancellationToken);
    }
}
