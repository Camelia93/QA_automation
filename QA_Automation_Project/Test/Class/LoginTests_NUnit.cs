using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Automation_Project.Pages;
using QA_Automation_Project.Core;
using System;
using System.Threading;

namespace QA_Automation_Project.Tests
{
    [TestFixture]
    public class LoginTests_NUnit
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.Manage().Window.Maximize();

            loginPage = new LoginPage(driver);
            Console.WriteLine("🔹 Browser inițializat și pagina de login deschisă.");
        }

        

        [Test]
        public void Login_With_Invalid_Password_Should_Show_Error()
        {
            var db = new DatabaseManager();
            var invalidUsers = db.GetAllUsers("invalid_logins");

            foreach (var (username, password) in invalidUsers)
            {
                Console.WriteLine($"🔹 Testez cu: {username} / {password}");

                loginPage.EnterUsername(username);
                loginPage.EnterPassword(password);
                loginPage.ClickLogin();
                Thread.Sleep(2000);

                string message = loginPage.GetMessageText();
                Assert.That(message.Contains("Your password is invalid!"),
                    $"❌ Mesajul de eroare NU a apărut pentru {username}!");
            }

            Console.WriteLine("✅ Testul pentru userii invalizi a trecut cu succes!");
        }

        [Test]
        public void Login_With_Valid_Credentials_Should_Pass()
        {
            var db = new DatabaseManager();

            try
            {
                var (username, password) = db.GetUserData("users", 2);

                loginPage.EnterUsername(username);
                loginPage.EnterPassword(password);
                loginPage.ClickLogin();
                Thread.Sleep(2000);

                string message = loginPage.GetMessageText();

                Assert.That(message.Contains("Congratulations"), "❌ Mesajul de succes nu a fost găsit!");
                Console.WriteLine($"🔍 Mesaj complet: {message}");

                db.SaveTestResult("Login_With_Valid_Credentials_Should_Pass", "Passed", "");
            }
            catch (Exception ex)
            {
                db.SaveTestResult("Login_With_Valid_Credentials_Should_Pass", "Failed", ex.Message);
                throw;
            }
        }



        [TestFixture]
        public class DatabaseTests_NUnit
        {
            [Test]
            public void Test_Database_Connection()
            {
                DatabaseManager db = new DatabaseManager();
                db.TestConnection();
                Assert.Pass("Conexiunea la baza de date a fost testată cu succes.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            Console.WriteLine("🧹 Browser închis și resurse eliberate.");
        }
    }
}

