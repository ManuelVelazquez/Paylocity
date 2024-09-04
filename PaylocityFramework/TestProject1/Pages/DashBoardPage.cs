using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Selenium;

namespace TestProject1.Pages
{
    public class DashBoardPage
    {
        //this class is part of our POM pattern design. 
        private readonly IWebDriver driver;

        public DashBoardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement btnLogOut => driver.FindElement(By.XPath("//a[@href = '/Prod/Account/LogOut']"), 5);
        IWebElement btnAddEmployee => driver.FindElement(By.Id("add"), 5);
        IWebElement txtFirstName => driver.FindElement(By.Id("firstName"), 5);
        IWebElement txtLastName => driver.FindElement(By.Id("lastName"), 5);
        IWebElement txtDependents => driver.FindElement(By.Id("dependants"), 5);
        IWebElement btnAddEmployeeForm => driver.FindElement(By.Id("addEmployee"), 5);
        IWebElement lnkDeleteEmployee => driver.FindElement(By.XPath("//table[@id= 'employeesTable']/tbody/tr/td[9]/i[2]"), 5);
        IWebElement btnDeleteEmployee => driver.FindElement(By.Id("deleteEmployee"), 5);
        IWebElement lnkUpdateEmployee => driver.FindElement(By.XPath("//table[@id= 'employeesTable']/tbody/tr/td[9]/i[1]"), 5);
        IWebElement btnUpdateEmployee => driver.FindElement(By.Id("updateEmployee"), 5);
        IWebElement btnCancelAddEmployeeForm => driver.FindElement(By.XPath("//button[text()='Cancel']"), 5);

        IWebElement btnCancelDeleteEmployeeForm => driver.FindElement(By.XPath("//div[@id='deleteModal']//button[text()='Cancel']"), 5);




        public bool isLogedIn()
        {
           return btnLogOut.Displayed;
        }

        public void addEmployee(string firstName, string lastName, string dependents)
        {
            Thread.Sleep(2000);
            int iRowsCount = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            btnAddEmployee.ClickOnAButton();
            ClassicAssert.IsTrue(isAddEmployeeFormDisplayed());
            txtFirstName.EnterText(firstName);
            txtLastName.EnterText(lastName);
            txtDependents.EnterText(dependents);
            btnAddEmployeeForm.ClickOnAButton();
            Thread.Sleep(3000);
            int iRowsCountAfterAdd = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            ClassicAssert.AreEqual(iRowsCountAfterAdd, iRowsCount + 1);

        }


        public void CanceladdEmployee(string firstName, string lastName, string dependents)
        {
            Thread.Sleep(2000);
            int iRowsCount = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            btnAddEmployee.ClickOnAButton();
            ClassicAssert.IsTrue(isAddEmployeeFormDisplayed());
            txtFirstName.EnterText(firstName);
            txtLastName.EnterText(lastName);
            txtDependents.EnterText(dependents);
            btnCancelAddEmployeeForm.ClickOnAButton();
            Thread.Sleep(3000);
            int iRowsCountAfterCancel = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            ClassicAssert.AreEqual(iRowsCountAfterCancel, iRowsCount );

        }

        public void deleteEmployee()
        {
            Thread.Sleep(2000);
            int iRowsCount = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            lnkDeleteEmployee.ClickOnAButton();
            btnDeleteEmployee.ClickOnAButton();
            Thread.Sleep(3000);
            int iRowsCountAfterDeletion = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            ClassicAssert.AreEqual(iRowsCountAfterDeletion, iRowsCount -1);

        }

        public void CanceldeleteEmployee()
        {
            Thread.Sleep(2000);
            int iRowsCount = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            lnkDeleteEmployee.ClickOnAButton();
            Thread.Sleep(2000);
            btnCancelDeleteEmployeeForm.ClickOnAButton();
            Thread.Sleep(1000);
            int iRowsCountAfterCancel = driver.FindElements(By.XPath("//table[@id= 'employeesTable']/tbody/tr")).Count;
            ClassicAssert.AreEqual(iRowsCountAfterCancel, iRowsCount );

        }

        public bool isAddEmployeeFormDisplayed()
        {
            return btnAddEmployeeForm.Displayed;
        }

        public void updateEmployee(string firstName, string lastName, string dependents)
        {
            lnkUpdateEmployee.ClickOnAButton();
            ClassicAssert.IsTrue(isUpdateEmployeeFormDisplayed());
            txtFirstName.EnterText(firstName);
            txtLastName.EnterText(lastName);
            txtDependents.EnterText(dependents);
            btnUpdateEmployee.ClickOnAButton();

        }

        public void cancelUpdateEmployee(string firstName, string lastName, string dependents)
        {
            lnkUpdateEmployee.ClickOnAButton();
            ClassicAssert.IsTrue(isUpdateEmployeeFormDisplayed());
            txtFirstName.EnterText(firstName);
            txtLastName.EnterText(lastName);
            txtDependents.EnterText(dependents);
            btnCancelAddEmployeeForm.ClickOnAButton();

        }

        public bool isUpdateEmployeeFormDisplayed()
        {
            return btnUpdateEmployee.Displayed;
        }

    }
}