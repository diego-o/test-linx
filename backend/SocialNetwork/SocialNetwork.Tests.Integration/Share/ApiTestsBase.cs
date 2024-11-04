using Newtonsoft.Json;
using System.Text;

namespace SocialNetwork.Tests.Integration.Share
{
    public class ApiTestsBase : IClassFixture<ApiTestFixture>
    {
        protected readonly HttpClient Client;

        public ApiTestsBase(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        protected HttpContent CreateContent<TObject>(TObject obj)
        {
            HttpContent httpContent = new StringContent(SerializeObject(obj), Encoding.UTF8, "application/json");
            return httpContent;
        }

        protected string SerializeObject<TObject>(TObject obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        protected TObject? DeserializeObject<TObject>(string content)
        {
            return JsonConvert.DeserializeObject<TObject>(content);
        }
    }
}
