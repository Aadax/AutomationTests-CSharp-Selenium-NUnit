using AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern;
using NUnit.Framework;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class DashboardTests : Base
    {
        [Test]
        [TestCase(Category = "Dashboard", TestName = "Login missing credential - negative authorization")]
        [Description("User should get redirected to the Time option")]
        public void DashboardPunchIn()
        {
            LoginPage loginPage = new LoginPage(Driver);
            Step("User logs in to the app");
            loginPage.LoginAs();
        }
    }
}
