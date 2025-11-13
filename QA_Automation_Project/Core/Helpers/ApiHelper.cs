using System.Net.Http;
using System.Threading.Tasks;

namespace QA_Automation_Project.Helpers
{
    public class ApiHelper
    {
        private readonly HttpClient _client;

        public ApiHelper()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetRequestAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }
    }
}
