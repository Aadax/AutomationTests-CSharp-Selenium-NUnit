using AutomationTests_CSharp_Selenium_NUnit.Fixture.DataModels.LoginCredentials;
using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class LoginPage : BasePage
    {
        public static readonly string BaseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public IWebElement Username => Find(By.XPath(".//input[@name= 'username']"));

        public IWebElement Password => Find(By.XPath(".//input[@name= 'password']"));

        private IWebElement LoginButton => Find(By.XPath(".//button[contains(@class, 'oxd-button') and @type= 'submit']"));

        public readonly By InvalidLoginAlert = By.XPath("//*[@class= 'orangehrm-login-error']/div[@role = 'alert']");

        public string InvalidLoginAlertText => Find(By.XPath("//*[@class= 'orangehrm-login-error']/div[@role = 'alert']")).Text; 

        public string InvalidCredentialsMessage => Find(By.XPath(".//span[contains(@class, 'input-field-error-message') and text()='Required']")).Text;

        private IWebElement ForgorPasswordButton => Find(By.XPath("//*[contains(@class, 'orangehrm-login-forgot-header') and normalize-space()='Forgot your password?']"));

        public LoginPage(IWebDriver Driver) : base(Driver) { }

        public void LoginButtonClick() => LoginButton.Click();

        public void ForgotPasswordButtonClick() => ForgorPasswordButton.Click();

        public void LoginAs()
        {
            var credentials = Credentials.Value;
            Login(credentials.Username, credentials.Password);
        }

        private void Login(string username, string password)
        {
            Username.Clear();
            Username.SendKeys(username);
            Password.Clear();
            Password.SendKeys(password);
            LoginButton.Click();
        }

        private static readonly Lazy<LoginCredentials> Credentials =
            new Lazy<LoginCredentials>(() =>
                Helpers.LoadJson<LoginCredentials>("Fixture/DataModels/LoginCredentials/LoginCredentials.json"));
    }
}