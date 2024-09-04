using OpenQA.Selenium;
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

        }
        // here are the test cases created
        [Test]
        public void LogInUnsuccesfully()
        {
           _loginPage.LogIn("abc", "def");
           ClassicAssert.IsTrue(_loginPage.unSuccesssfullLogIn());

        }

        [Test]
        public void LogInSuccessfully()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            ClassicAssert.IsTrue(_dashBoard.isLogedIn());

        }

        [Test]
        public void AddEmployee()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            _dashBoard.addEmployee("Juan", "Perez", "0");           
        }

        [Test]
        public void CancelAddEmployee()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            _dashBoard.CanceladdEmployee("Juan", "Perez", "0");
        }

        [Test]
        public void DeleteEmployee()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            _dashBoard.deleteEmployee();         
        }

        [Test]
        public void CancelDeleteEmployee()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            _dashBoard.CanceldeleteEmployee();
        }

        [Test]
        public void UpdateEmployee()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            _dashBoard.updateEmployee("NameUpdated", "LastNameUpdated", "0");
        }

        [Test]
        public void CancelUpdateEmployee()
        {
            _loginPage.LogIn("TestUser431", "G[#GJwjV_Hl1");
            _dashBoard.cancelUpdateEmployee("NameUpdated", "LastNameUpdated", "0");
        }
    }
}