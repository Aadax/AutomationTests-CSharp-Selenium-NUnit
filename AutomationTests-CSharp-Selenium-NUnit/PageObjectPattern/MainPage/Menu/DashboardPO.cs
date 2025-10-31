using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class DashboardPO : BaseElement
    {
        private IWebElement PunchInButton => Find(By.XPath(".//button[contains(@class, 'attendance-card-action') and @type = 'button']"));

        public DashboardPO(IWebElement element) : base(element)
        {
            new Actions(GetDriver()).MoveToElement(element).Perform();
            Wait.Until(ExpectedConditions.ElementNotChanging(element));
        }

        public void PunchInButtonClick() => PunchInButton.Click();
    }
}