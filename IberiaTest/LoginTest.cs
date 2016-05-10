using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System.Data;

namespace IberiaTest
{
    [TestClass]
    public class LoginTest : BaseClass
    {
        //Need to add comments here
        public LoginTest() : base()
        {
            
        }

        public static TestContext BingTestContext
        {
            get { return LoginTest.bingTestContext; }
            set { LoginTest.bingTestContext = value; }
        }
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            // MessageBox.Show("AssemblyInit " + context.TestName);
            BingTestContext = context;
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // MessageBox.Show("ClassInit " + context.TestName);
            BingTestContext = context;
        }

        public void CreateDriverObject(string browserType)
        {
            if (browserType == "Chrome")
            {
                driver = new ChromeDriver();
            }
            else if (browserType == "InternetExplorer")
            {
                driver = new InternetExplorerDriver();
            }
            else if (browserType == "Firefox")
            {
                driver = new FirefoxDriver();
            }
            //else if (browserType == "Safari")
            //{
            //    driver = new SafariDriver();
            //}
            driver.Navigate().GoToUrl("https://dfw-xapp1-st.dnet3.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(10000);
        }

        [TestMethod]
        public void Login_Successful()
        {
            test = extent.StartTest("LoginSuccess");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            login(driver, "johnsmith", "Iberia123!", "denver");
            Thread.Sleep(1000);
        }
        public void login(IWebDriver _driver, string userName, string password, string secAns)
        {
            try
            {
               
                IberiademoPage page = new IberiademoPage(_driver);
                while (!page.UserName.Displayed) { }
                page.UserName.SendKeys(userName);
                test.Log(LogStatus.Pass, "Enter valid user name");
                page.Password.Click();
                page.Password.SendKeys(password);
                test.Log(LogStatus.Pass, "Enter valid password");
                page.SubmitButton.Click();
                test.Log(LogStatus.Pass, "Select Submit");
                if (!string.IsNullOrEmpty(secAns))
                {
                    Thread.Sleep(1000);
                    page.SecurityAnswer.SendKeys(secAns);
                    test.Log(LogStatus.Pass, "Enter Valid Security Answer");
                    page.SubmitButton.Click();
                    test.Log(LogStatus.Pass, "Select Submit");
                    while (page.DashboardElem.Text != "My Bank Account")
                    {

                    }
                    Thread.Sleep(1000);
                    page.logout.Click();
                    ExportToExcel("Authentication", "Login_Successful", "User Logs Successfully", "Kishore", "Pass", "Automation", "Iberiademo");
                    test.Log(LogStatus.Pass, "Logout");
                    extent.EndTest(test);
                    extent.Flush();
                    extent.Close();
                }

            }
            catch (Exception ex)
            {
                ExportToExcel("Authentication", "Login_Successful", "User Logs Successfully", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();

                throw ex;

            }
            finally
            {



            }
        }
        [TestMethod]
        public void Login_Unsuccesful_UserName()
        {
            test = extent.StartTest("LoginUnsucces");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            loginFail(driver, "ivanfreely", "pasword");
            Thread.Sleep(10000);
        }
        public void loginFail(IWebDriver _driver, string userName, string password)
        {
            try {
                IberiademoPage page = new IberiademoPage(_driver);
                //string username = page.UserName.Text;
                page.UserName.SendKeys(userName);
                test.Log(LogStatus.Pass, "Enter UserName");
                page.Password.Click();
                page.Password.SendKeys(password);
                test.Log(LogStatus.Pass, "Enter Password");
                page.Forgotlink.Click();
                test.Log(LogStatus.Pass, "Click On Forgot Link");
                //Assert.IsTrue(username.Equals(userName));
                ExportToExcel("Authentication", "Login_Unsuccesful_UserName", "User Logs in with Invalid UserName", "Kishore", "Pass", "Automation", "Iberiademo");
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
            }
            catch (Exception ex)
            {
                ExportToExcel("Authentication", "Login_Unsuccesful_UserName", "User Logs in with Invalid UserName", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
              
                extent.Close();

                throw ex;

            }
            finally
            {



            }

        }

        [TestMethod]
        public void Login_Unsuccessful_Password()
        {
            test = extent.StartTest("PasswordFailure");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            PasswordFailure(driver, "samueladamsiii", "test");
            Thread.Sleep(1000);
        }
        public void PasswordFailure(IWebDriver _driver, string userName, string password)
        {
            try {
                IberiademoPage page = new IberiademoPage(_driver);
                page.UserName.SendKeys(userName);
                test.Log(LogStatus.Pass, "Enter UserName ");
                page.Password.Click();
                page.Password.SendKeys(password);
                test.Log(LogStatus.Pass, "Enter Password");
                page.SubmitButton.Click();
                test.Log(LogStatus.Pass, "Click Submit Button");
                ExportToExcel("Authentication", "Login_Unsuccessful_Password", "User Logs With Invalid Password", "Kishore", "Pass", "Automation", "Iberiademo");
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
            }
            catch (Exception ex)
            {
                ExportToExcel("Authentication", "Login_Unsuccessful_Password", "User Logs With Invalid Password", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();

                throw ex;
            }
            finally
            {

            }
        }

        [TestMethod]
        public void Login_ForgotPassword()
        {
            test = extent.StartTest("ForgotPassword");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            ForgotPassword(driver, "samueladamsiii");
            Thread.Sleep(1000);
        }
        public void ForgotPassword(IWebDriver _driver, string userName)
        {
            try
            {

                IberiademoPage page = new IberiademoPage(_driver);
                page.UserName.SendKeys(userName);
                test.Log(LogStatus.Pass, "Enter UserName ");
                page.Password.Click();
                page.Forgotlink.Click();
                ExportToExcel("Authentication", "Login_ForgotPassword", "User Logs With valid username And Request password reset", "Kishore", "Pass", "Automation", "Iberiademo");
                test.Log(LogStatus.Pass, "Click On Forgot Link");
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
            }
            catch (Exception ex)
            {
                ExportToExcel("Authentication", "Login_ForgotPassword", "User Logs With valid username And Request password reset", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();

                throw ex;

            }
            finally
            {

            }

        }


        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        
    }
}
