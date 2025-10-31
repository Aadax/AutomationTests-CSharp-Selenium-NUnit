using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class Organization : BaseElement
    {
        public Organization(IWebElement element) : base(element)
        {
            new Actions(GetDriver()).MoveToElement(element).Perform();
            Wait.Until(ExpectedConditions.ElementNotChanging(element));
        }
    }
}