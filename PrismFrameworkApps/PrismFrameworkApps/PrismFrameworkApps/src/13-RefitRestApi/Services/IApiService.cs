using Fusillade;

namespace PrismFrameworkApps.src._13_RefitRestApi.Services
{
    // Create API Service
    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
