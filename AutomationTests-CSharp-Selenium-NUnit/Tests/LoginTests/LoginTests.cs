using NUnit.Framework;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    [TestFixture]
    public class LoginTests : Base
    {
        //[TestCaseSource(typeof(LoginData), "Login")]
        [Test]
        public void TestMethod()
        {
            LoginPO login = new LoginPO(Driver);

            login.Username.SendKeys("Admin");
            login.Password.SendKeys("admin123");
            //login.SendKe("Admin");
            //login.FillInput("admin123");
            login.LoginButtonClick();
            Thread.Sleep(6000);
        }
    }
}