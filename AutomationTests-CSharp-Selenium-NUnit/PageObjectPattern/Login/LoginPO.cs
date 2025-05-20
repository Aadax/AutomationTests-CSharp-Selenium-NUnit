using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class LoginPO : BasePage
    {
        public static readonly string BaseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public IWebElement Username => Find(By.XPath(".//input[@name= 'username']"));

        public IWebElement Password => Find(By.XPath(".//input[@name= 'password']"));

        private IWebElement LoginButton => Find(By.XPath(".//button[contains(@class, 'oxd-button') and @type= 'submit']"));

        public readonly By InvalidLoginAlert = By.XPath("//*[@class= 'orangehrm-login-error']/div[@role = 'alert']");

        public string InvalidCredentialsMessage => Find(By.XPath(".//span[contains(@class, 'input-field-error-message') and text()='Required']")).Text;

        private IWebElement ForgorPasswordButton => Find(By.XPath("//*[contains(@class, 'orangehrm-login-forgot-header') and normalize-space()='Forgot your password?']"));

        public LoginPO(IWebDriver Driver) : base(Driver) { }

        public void LoginButtonClick() => LoginButton.Click();

        public void ForgotPasswordButtonClick() => ForgorPasswordButton.Click();
    }
}