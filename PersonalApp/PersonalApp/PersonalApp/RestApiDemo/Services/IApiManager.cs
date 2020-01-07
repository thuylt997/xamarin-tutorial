using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalApp.RestApiDemo.Services
{
    public interface IApiManager
    {
        Task<HttpResponseMessage> GetMakeUps(string brand);
    }
}
