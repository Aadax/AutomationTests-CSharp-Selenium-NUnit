using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class ResetPasswordPO : BasePage
    {
        public string Header => Find(By.XPath("//*[@class = 'orangehrm-card-container']//h6[contains(@class, 'forgot-password-title')]")).Text;
        private IWebElement CancelButton => Find(By.XPath(".//button[contains(@class, 'forgot-password-button--cancel')]"));

        private IWebElement ResetPasswordButton => Find(By.XPath(".//button[contains(@class, 'secondary orangehrm-forgot-password-button')]"));

        public IWebElement UsernameInput => Find(By.XPath(".//input[@name = 'username']"));

        public ResetPasswordPO(IWebDriver Driver) : base(Driver)
        {
            Assert.That(Header, Is.EqualTo("Reset Password"));
        }

        public void CancelButtonClick() => CancelButton.Click();

        public void ResetPasswordButtonClick() => ResetPasswordButton.Click();
    }
}