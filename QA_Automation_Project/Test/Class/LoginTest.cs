//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using QA_Automation_Project.Pages;

//namespace QA_Automation_Project.Tests
//{
//    public class LoginTest
//    {
//        //public static void Main(string[] args)
//        {
//            IWebDriver driver = new ChromeDriver();
//            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
//            driver.Manage().Window.Maximize();

//            // Inițializează pagina de login
//            var loginPage = new LoginPage(driver);

//            // Rulează testul - login corect
//            loginPage.EnterUsername("studetnt");
//            loginPage.EnterPassword("gresit123");
//            loginPage.ClickLogin();

//            Thread.Sleep(3000); // așteaptă răspunsul paginii

//            string message = loginPage.GetMessageText();
//            Console.WriteLine("Mesajul afișat: " + message);

//            if (message.Contains("successfully logged in"))
//            {
//                Console.WriteLine("✅ Test PASSED!");
//            }
//            else
//            {
//                Console.WriteLine("❌ Test FAILED!");
//            }

//            driver.Close();
//        }
//    }
//}

