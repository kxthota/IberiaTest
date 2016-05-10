using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace IberiaTest
{
    public class IberiademoPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "challengePassword")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='challenge-form']/div[3]/button[3]")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "challengeUsername")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "secretQuestionAnswer")]
        public IWebElement SecurityAnswer { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/header/div[1]/div/div[3]/div/ul/li[3]/a")]
        public IWebElement logout { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='reset-link']/button")]
        public IWebElement Forgotlink { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/nav/div[2]/div/ul/li[3]/a/div[1]")]
        public IWebElement Accountlink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/section[1]/section[2]/ul/li[2]/div")]
        public IWebElement selectSavings { get; set; }

        [FindsBy(How =How.XPath,Using = "//*[@id='main']/div/section/div[2]/div[1]/div[2]/div/article[1]/header/h2")]
        public IWebElement DashboardElem { get; set; }

        [FindsBy(How = How.ClassName, Using = "balance")]
        public IWebElement CurrentBalance { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/nav/div[2]/div/ul/li[3]/a")]
        public IWebElement AccountsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/section[1]/section[2]/ul/li[1]/div[1]")]
        public IWebElement AccountsLinkOpen { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/section[1]/section[2]/ul/li[1]/div/div/div[2]/p[1]/span")]
        public IWebElement Currentbalncelabel { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement LastStatementBalance { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/section[1]/section[2]/ul")]
        public IWebElement SavingsAccountLabel { get; set; }

        public IberiademoPage() { }

        public IberiademoPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;


            //if (!webDriver.Url.Contains("Login.aspx"))
            //{
            //    throw new StaleElementReferenceException("This is not the login page");
            //}
            PageFactory.InitElements(webDriver, this);
        }

        public void signIn(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            SubmitButton.Submit();
            
        }
    }
}
