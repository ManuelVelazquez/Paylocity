using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Selenium;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        //this class is part of our POM pattern design. 
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement txtUserName => driver.FindElement(By.Id("Username"),5);
        IWebElement txtPassword => driver.FindElement(By.Id("Password"),5);
        IWebElement btnLogin => driver.FindElement(By.XPath("//button[@class = 'btn btn-primary']"),5);
        IWebElement lblThisPageIsNotWorking => driver.FindElement(By.XPath("//div[@id = 'main-message']/h1/span[text()='This page isn’t working']"), 5);



        public void LogIn(string userName , string password)
        {
            txtUserName.EnterText(userName);
            txtPassword.EnterText(password);
            btnLogin.Click();
        }

        public bool unSuccesssfullLogIn()
        {
            return lblThisPageIsNotWorking.Displayed;
        }

    }
}
