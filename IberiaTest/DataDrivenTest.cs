using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System.Data;
using IberiaTest;

namespace Iberiademo
{
    [TestClass]
    public class DataDrivenTest
    {
        public IWebDriver driver = null;

        [TestInitialize]
        public void IntializeTestSuccess()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://dfw-xapp1-st.dnet3.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            ExcelLib.PopulateInCollection(@"H:\Data.xlsx");
            IberiademoPage page = new IberiademoPage(driver);
            page.signIn(ExcelLib.ReadData(1, "UserName"), ExcelLib.ReadData(1, "Password")); 
        }
    }
}
