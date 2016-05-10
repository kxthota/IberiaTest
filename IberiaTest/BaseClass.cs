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

namespace IberiaTest
{
    public class BaseClass
    {
        public IWebDriver driver = null;
        public  ExtentReports extent;
        public  ExtentTest test = null;
        public static TestContext bingTestContext;
        public DataTable dt = new DataTable();
        public string[] columns = { "Component", "TestName", "Objective", "Responsible tester", "Date of Execution", "Status", "TestType" };
        public BaseClass()
        {
            extent = new ExtentReports("IberiademoTestResults.html", false, DisplayOrder.NewestFirst);
            extent.LoadConfig(@"C:\Users\kthota\Source\Workspaces\Iberiademo\Iberiademo\extent-config.xml");
        }

        [TestInitialize]
        public void IntializeTestSuccess()
        {
            //ExcelLib lib = new ExcelLib();
            //ExcelLib.PopulateInCollection(@"H:\Data.xlsx");

            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string fullPath = Path.Combine(wanted_path, @"IberiaTest\Drivers");
            driver = new ChromeDriver(fullPath);
            driver.Navigate().GoToUrl("https://dfw-xapp1-st.dnet3.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            foreach (var columnName in columns)
            {
                DataColumn dc = new DataColumn(columnName);
                dt.Columns.Add(dc);
            }
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Quit();
        }

        public void ExportToExcel(string component, string testName,
                string objective, string tester, string status, string testtype, string tableName)
        {
            DataRow dr = dt.NewRow();
            dr["Component"] = component;
            dr["TestName"] = testName;
            dr["Objective"] = objective; 
            dr["Responsible tester"] = tester;
            dr["Date of Execution"] = DateTime.Now.ToString();
            dr["Status"] = status;
            dr["TestType"] = testtype;
            //dr["ExportValue"] = exportvalue; 
            dt.Rows.Add(dr); dt.TableName = tableName;
            Helper.GenerateExcel2007(dt);
        }
    }
}
