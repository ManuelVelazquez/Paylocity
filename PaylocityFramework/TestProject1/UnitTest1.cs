using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1.Pages;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TestProject1
{
    public class TestCasesPaylocity
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private LoginPage _loginPage;
        private DashBoardPage _dashBoard;

        [SetUp]
        public void Setup()
        {
            _driver= new ChromeDriver();
             _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _loginPage = new LoginPage(_driver);
            _dashBoard = new DashBoardPage(_driver);

            _driver.Navigate().GoToUrl("https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login");
            _driver.Manage().Window.Maximize();
            _loginPage.LogIn("TestUser759", "!|XY*0c-N#+*");

        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Close();
        
        }
        // here are the test cases 
        [Test]
        public void LogInUnsuccesfully()
        {
            _dashBoard.logOut();
           _loginPage.LogIn("abc", "def");
           ClassicAssert.IsTrue(_loginPage.unSuccesssfullLogIn());
            
        }

        [Test]
        public void LogInSuccessfully()
        {
            ClassicAssert.IsTrue(_dashBoard.isLogedIn());

        }

        [Test]
        public void AddEmployee()
        {
            _dashBoard.addEmployee("Juan", "Perez", "0");   
        }

        [Test]
        public void CancelAddEmployee()
        {
            _dashBoard.CanceladdEmployee("Juan", "Perez", "0");
        }

        [Test]
        public void DeleteEmployee()
        {
            _dashBoard.deleteEmployee();         
        }

        [Test]
        public void CancelDeleteEmployee()
        {
            _dashBoard.CanceldeleteEmployee();
        }

        [Test]
        public void UpdateEmployee()
        {
            _dashBoard.updateEmployee("NameUpdated", "LastNameUpdated", "0");
        }

        [Test]
        public void CancelUpdateEmployee()
        {
            _dashBoard.cancelUpdateEmployee("NameUpdated", "LastNameUpdated", "0");
        }
    }
}