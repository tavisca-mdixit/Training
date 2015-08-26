using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AspAutomationTesting
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void HrLoginTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("isha@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("test123");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            string currentURL = driver.Url;

            Assert.AreEqual(currentURL, "http://localhost:58084/HrPage.aspx");
        }
        //MainContent_ErrorMessageEmployee
        [TestMethod]
        public void CheckEmployeeCreatedTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("isha@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("test123");

            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            //driver.FindElement(By.Name("AddEmploye")).Click();
            driver.FindElement(By.Id("MainContent_FirstName")).SendKeys("ashwini");
            driver.FindElement(By.Id("MainContent_LastName")).SendKeys("Kardelay");

            driver.FindElement(By.Id("MainContent_EmpTitle")).SendKeys("Employee");
            driver.FindElement(By.Id("MainContent_Email")).SendKeys("neil14333@gmail.com");
            driver.FindElement(By.Id("MainContent_Phone")).SendKeys("44455566");
            driver.FindElement(By.Id("MainContent_DOJ")).SendKeys("2015/02/02");
            driver.FindElement(By.Name("ctl00$MainContent$Submit")).Click();
            string message = driver.FindElement(By.Id("MainContent_ErrorMessageEmployee")).Text;
            Assert.AreEqual(message, "Request processed suceesfully");




        }


        [TestMethod]
        public void LogoutSuccessfullTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("isha@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("test123");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            driver.FindElement(By.Id("MainContent_Button1")).Click();

            string currentURL = driver.Url;

            Assert.AreEqual(currentURL, "http://localhost:58084/Login.aspx");


        }

        [TestMethod]
        public void EmployeeLoginTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("a@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("a");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();

            string currentURL = driver.Url;

            Assert.AreEqual(currentURL, "http://localhost:58084/EmployeePage.aspx");


        }
        [TestMethod]
        public void EmployeePasswordChangeSuccessTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("a@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("a");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            driver.FindElement(By.Id("MainContent_Button2")).Click();

            driver.FindElement(By.Id("MainContent_OldPass")).SendKeys("a");
            driver.FindElement(By.Id("MainContent_NewPass")).SendKeys("aa");

            driver.FindElement(By.Name("ctl00$MainContent$Button1")).Click();

            string message = driver.FindElement(By.Id("MainContent_Message")).Text;

            Assert.AreEqual(message, "Success");
        }
        [TestMethod]
        public void EmployeePasswordChangeFailTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("a@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("a");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            driver.FindElement(By.Id("MainContent_Button2")).Click();

            driver.FindElement(By.Id("MainContent_OldPass")).SendKeys("aa");
            driver.FindElement(By.Id("MainContent_NewPass")).SendKeys("a");

            driver.FindElement(By.Name("ctl00$MainContent$Button1")).Click();

            string message = driver.FindElement(By.Id("MainContent_Message")).Text;

            Assert.AreNotEqual(message, "Success");
        }


        [TestMethod]
        public void CheckRemarkCreatedTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("isha@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("test123");

            driver.FindElement(By.Id("MainContent_AddRemark")).Click();
            var continents = driver.FindElement(By.Name("continents"));

            var selectIndex = new SelectElement(continents);
            selectIndex.SelectByIndex(3);
            driver.FindElement(By.Id("MainContent_EmpRemarkBox")).SendKeys("Selenium Testing");
            driver.FindElement(By.Name("ctl00$MainContent$EmpRemarkButton")).Click();


            string message = driver.FindElement(By.Id("MainContent_ErrorMessage")).Text;
            Assert.AreEqual(message, "Request processed suceesfully");

        }
        public void HrPasswordChangeSuccessTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("a@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("a");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            driver.FindElement(By.Id("MainContent_PasswordChange")).Click();

            driver.FindElement(By.Id("MainContent_OldPass")).SendKeys("a");
            driver.FindElement(By.Id("MainContent_NewPass")).SendKeys("aa");

            driver.FindElement(By.Name("ctl00$MainContent$Button1")).Click();

            string message = driver.FindElement(By.Id("MainContent_Message")).Text;

            Assert.AreEqual(message, "Success");
        }
        public void HrPasswordChangeFailTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:58084/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox1")).SendKeys("a@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl1_TextBox2")).SendKeys("a");
            driver.FindElement(By.Name("ctl00$MainContent$LoginUserControl1$LoginButton")).Click();
            driver.FindElement(By.Id("MainContent_PasswordChange")).Click();

            driver.FindElement(By.Id("MainContent_OldPass")).SendKeys("aa");
            driver.FindElement(By.Id("MainContent_NewPass")).SendKeys("a");

            driver.FindElement(By.Name("ctl00$MainContent$Button1")).Click();

            string message = driver.FindElement(By.Id("MainContent_Message")).Text;

            Assert.AreEqual(message, "Failed");
        }


    }
}
