using OpenQA.Selenium;

using OpenQA.Selenium;

namespace QA_Automation_Project.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        // --- Constructor ---
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // --- Elemente din pagină ---
        private IWebElement UsernameField => driver.FindElement(By.Id("username"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("submit"));
        private IWebElement Message => driver.FindElement(By.Id("error"));

        // --- Acțiuni ---
        public void EnterUsername(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public string GetMessageText()
        {
            return driver.FindElement(By.CssSelector(".post-content")).Text;
        }
    }
}
