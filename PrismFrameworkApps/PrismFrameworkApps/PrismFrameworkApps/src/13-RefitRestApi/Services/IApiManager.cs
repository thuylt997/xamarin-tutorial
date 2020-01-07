using System.Net.Http;
using System.Threading.Tasks;

namespace PrismFrameworkApps.src._13_RefitRestApi.Services
{

    // Create API Manager
    public interface IApiManager
    {
        Task<HttpResponseMessage> GetMakeUps(string brand);
        Task<HttpResponseMessage> GetNews();
    }
}
