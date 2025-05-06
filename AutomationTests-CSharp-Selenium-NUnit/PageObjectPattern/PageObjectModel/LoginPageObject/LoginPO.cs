using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class LoginPO : BasePage
    {
        public static readonly string BaseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public IWebElement Username => Find(By.XPath(".//input[@name= 'username']"));

        public IWebElement Password => Find(By.XPath(".//input[@name= 'password']"));

        private IWebElement LoginButton => Find(By.XPath(".//button[contains(@class, 'oxd-button') and @type= 'submit']"));

        public LoginPO(IWebDriver Driver) : base(Driver) { }

        //public void FillInput(string text)
        //{
        //    Username.Clear();
        //    Username.SendKeys(text);
        //}

        public void LoginButtonClick() => LoginButton.Click();
    }
}