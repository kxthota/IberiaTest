using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Web;
using System.Web.Hosting;
using System.Linq;
using System.Collections.Generic;

namespace IberiaTest
{
    [TestClass]
    public class AccountTest : BaseClass
    {
        IberiademoPage page = null;
        [TestMethod]
        public void ACCT_Navigate()
        {
            page.AccountsLinkOpen.Click();
        }

        [TestInitialize]
        public void AccountTestInitialize()
        {
            test = extent.StartTest("AcctNavigate");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            ACCT_Navigate(driver, "ivanfreely", "Iberia123!", "denver");
            Thread.Sleep(1000);
        }

        public void ACCT_Navigate(IWebDriver _driver, string userName, string password, string secAns)
        {
            page = new IberiademoPage(_driver);
            page.UserName.SendKeys(userName);
            page.Password.SendKeys(password);
            page.SubmitButton.Click();
            Thread.Sleep(1000);
            page.SecurityAnswer.SendKeys(secAns);
            page.SubmitButton.Click();
            Thread.Sleep(1000);
            page.AccountsLink.Click();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void ACCT_ATTR_SAV_CURBAL() 
        {
            try
            {
                string currentLableText = page.Currentbalncelabel.Text;
                Assert.IsNotNull(currentLableText);
                Assert.AreNotEqual(currentLableText.Trim(), string.Empty);
                ExportToExcel("Accounts", "ACCT_ATTR_SAV_CURBAL", "Validate the Current Balance Label", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_SAV_CURBAL", "Validate the Current Balance Label", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }

        }
        [TestMethod]
        public void ACCT_ATTR_SAV_LSTSTMBAL()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objBalance = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objBalance = accountDetails.Where(item => item == "Last Statement Balance").ToList();
                }
                Assert.IsTrue(objBalance.Count() > 0);
                ExportToExcel("Accounts", "ACCT_ATTR_SAV_LSTSTMBAL", "Validate the Last Statement Balance Label", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_SAV_LSTSTMBAL", "Validate the Last Statement Balance Label", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }

        }


        [TestMethod]
        public void ACT_ATTR_SAV_DATE_LSTSTM()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstDate = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objLstDate = accountDetails.Where(item => item == "Last Statement Date").ToList();
                }
                Assert.IsTrue(objLstDate.Count() > 0);
                ExportToExcel("Accounts", "ACT_ATTR_SAV_DATE_LSTSTM", "Validate the Last Statement Date Balance Label", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACT_ATTR_SAV_DATE_LSTSTM", "Validate the Last Statement Date Balance Label", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }

        }

        [TestMethod]
        public void ACCT_ATTR_SAV_INTRate()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstRate = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objLstRate = accountDetails.Where(item => item == "Interest Rate").ToList();
                }
                Assert.IsTrue(objLstRate.Count() > 0);
                ExportToExcel("Accounts", "ACCT_ATTR_SAV_INTRate", "Validate the Interest Rate Label", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_SAV_INTRate", "Validate the Interest Rate Label", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }
        }

        [TestMethod]
        public void ACCT_STTR_SAV_YTD()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstytd = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objLstytd = accountDetails.Where(item => item == "YTD").ToList();
                }
                Assert.IsTrue(objLstytd.Count() > 0);
                ExportToExcel("Accounts", "ACCT_STTR_SAV_YTD", "Validate the YTD Label", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_STTR_SAV_YTD", "Validate the YTD Label", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }

        }

        [TestMethod]
        public void ACCT_ATTR_XMAS_CURBAL()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstXmasBal = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objLstXmasBal = accountDetails.Where(item => item == "Current Balance").ToList();
                }
                Assert.IsTrue(objLstXmasBal.Count() > 0);
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_CURBAL", "Validate the Current Balance Label", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_CURBAL", "Validate the Current Balance Label", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }
        }

        [TestMethod]
        public void ACCT_ATTR_XMAS_DATELSTDEP()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstXmasBal = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objLstXmasBal = accountDetails.Where(item => item == "Date of last deposit").ToList();
                }
                Assert.IsTrue(objLstXmasBal.Count() > 0);
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_DATELSTDEP", "Validate the label for Date of last deposit", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_DATELSTDEP", "Validate the label for Date of last deposit", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }
        }

        [TestMethod]
        public void ACCT_ATTR_XMAS_INTRate()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstXmasInt = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    objLstXmasInt = accountDetails.Where(item => item == "Interest Rate").ToList();
                }
                Assert.IsTrue(objLstXmasInt.Count() > 0);
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_INTRate", "Validate the label for the Interest Rate", "Kishore", "Pass", "Automation", "Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_INTRate", "Validate the label for the Interest Rate", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }
        }
        
            [TestMethod]
        public void ACCT_ATTR_XMAS_YTD()
        {
            try
            {
                var description = driver.FindElements(By.XPath("//*[@id='main']/div/section[1]/section[2]/ul/li"));
                List<string> objLstXmasYTD = new List<string>();
                foreach (IWebElement option in description)
                {
                    string[] accountDetails = option.Text.Split('\r');
                    //if (accountDetails[0].Contains(""))
                    //{
                    objLstXmasYTD = accountDetails.Where(item => item == "YTD").ToList();
                    //}
                }
                Assert.IsTrue(objLstXmasYTD.Count() > 0);
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_YTD", "Validate the YTD label display","Kishore","Pass","Automation","Iberiademo");
            }
            catch (Exception ex)
            {
                ExportToExcel("Accounts", "ACCT_ATTR_XMAS_YTD", "Validate the YTD label display", "Kishore", "Fail", "Automation", "Iberiademo");
                test.Log(LogStatus.Fail, ex.Message);
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
                throw ex;
            }
        }



    }
}
