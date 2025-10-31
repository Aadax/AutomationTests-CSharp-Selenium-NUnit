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
            LoginPO loginPO = new LoginPO(Driver);
            Step("User logs in to the app");
            loginPO.Username.SendKeys("Admin");
            loginPO.Password.SendKeys("admin123");
            loginPO.LoginButtonClick();
            
            //TODO
            //DashboardPO dashboard = new DashboardPO(element);
        }
    }
}
