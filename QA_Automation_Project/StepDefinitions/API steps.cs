using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using QA_Automation_Project.Helpers;

namespace QA_Automation_Project.StepDefinitions
{
    [Binding]
    public class ApiSteps
    {
        private string _endpoint;
        private HttpResponseMessage _response;
        private readonly ApiHelper _apiHelper = new ApiHelper();

        [Given(@"I have the API endpoint ""(.*)""")]
        public void GivenIHaveTheAPIEndpoint(string url)
        {
            _endpoint = url;
        }

        [When(@"I send a GET request")]
        public async Task WhenISendAGetRequest()
        {
            _response = await _apiHelper.GetRequestAsync(_endpoint);
        }

        [Then(@"the response status should be (.*)")]
        public void ThenTheResponseStatusShouldBe(int statusCode)
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(statusCode),
                $"Expected status {statusCode}, but got {(int)_response.StatusCode}");
        }

        [Then(@"the response should contain the user email ""(.*)""")]
        public async Task ThenTheResponseShouldContainTheUserEmail(string expectedEmail)
        {
            string content = await _apiHelper.GetResponseContentAsync(_response);
            Console.WriteLine($"Actual status: {(int)_response.StatusCode}");
            Console.WriteLine($"Response body: {await _response.Content.ReadAsStringAsync()}");
            Assert.That(content.Contains(expectedEmail), $"Email {expectedEmail} not found in response!");
        }
    }
}
