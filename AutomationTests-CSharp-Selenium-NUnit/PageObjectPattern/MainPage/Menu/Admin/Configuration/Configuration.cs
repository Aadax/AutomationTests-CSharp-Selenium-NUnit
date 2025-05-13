using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class Configuration : BaseElement
    {
        public Configuration(IWebElement element) : base(element)
        {
            new Actions(GetDriver()).MoveToElement(element).Perform();
            Wait.Until(ExpectedConditions.ElementNotChanging(element));
        }
    }
}
