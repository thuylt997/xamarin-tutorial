using PersonalApp.RestApiDemo.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalApp.RestApiDemo.Services
{
    // Add Headers - Static
    [Headers("Content-Type: application/json")]
    public interface IMakeUpApi
    {
        // JSON
        //[Get("/api/v1/products.json?brand={brand}")]
        //Task<List<MakeUp>> GetMakeUps(string brand);

        // JSON HttpResponseMessage
        [Get("/api/v1/products.json?brand={brand}")]
        Task<HttpResponseMessage> GetMakeUps(string brand);

        // JSON
        [Post("/api/v1/addMakeUp")]
        Task<MakeUp> CreateMakeUp([Body] MakeUp makeUp, [Header("Authorization")] string token);

        // Form POST
        //[Post("/api/v1/addMakeUp")]
        //Task<MakeUp> CreateMakeUp([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    }
}
