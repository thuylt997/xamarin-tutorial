using Fusillade;

namespace PersonalApp.RestApiDemo.Services
{
    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
