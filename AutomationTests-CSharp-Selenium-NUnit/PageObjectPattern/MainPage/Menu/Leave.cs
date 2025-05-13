using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class Leave : BaseElement
    {
        public Leave(IWebElement element) : base(element)
        {
            new Actions(GetDriver()).MoveToElement(element).Perform();
            Wait.Until(ExpectedConditions.ElementNotChanging(element));
        }
    }
}
