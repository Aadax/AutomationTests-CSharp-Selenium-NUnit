using NUnit.Framework;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    [TestFixture]
    [Category("Login Tests")]
    public class LoginTests : Base
    {
        [TestCase(TestName = "Login Authorization")]
        [Description("User is able to log in to the app.")]
        public void TestMethod()
        {
            LoginPO login = new LoginPO(Driver);
            Step("User enter nickname");
            login.Username.SendKeys("Admin");
            Step("User enter password");
            login.Password.SendKeys("admin123");
            Step("User click on login button");
            login.LoginButtonClick();
        }
    }
}