using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System;
using System.Threading;

namespace QA_Automation_Project.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private string baseUrl = "https://practicetestautomation.com/practice-test-login/";

        [Given(@"I open the login page")]
        public void GivenIOpenTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine("🔹 Login page opened successfully.");
        }

        [When(@"I enter ""(.*)"" as username and ""(.*)"" as password")]
        public void WhenIEnterAsUsernameAndAsPassword(string username, string password)
        {
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);
        }

        [Then(@"I should see the error message ""(.*)""")]
        public void ThenIShouldSeeTheErrorPagePage()
        {
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("Your username is invalid!"),
                $"Expected URL to contain 'Your username is invalid!' but got {currentUrl}");
        }
        [Then(@"I should be redirected to the success page")]
        public void ThenIShouldBeRedirectedToTheSuccessPage()
        {
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("logged-in-successfully"),
                $"Expected URL to contain 'logged-in-successfully' but got {currentUrl}");
        }

        [Then(@"I should see the ""(.*)"" button")]
        public void ThenIShouldSeeTheButton(string buttonText)
        {
            var logoutButton = driver.FindElement(By.XPath("//a[contains(text(), 'Log out')]"));
            Assert.That(logoutButton.Displayed, $"{buttonText} button not found!");
            Console.WriteLine("✅ Logout button is visible — login successful.");
            driver.Quit();
        }
    }
}
