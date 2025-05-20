using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class Menu : BasePage
    {
        public IWebElement Search => Find(By.XPath("//*[@class = 'oxd-sidepanel-body']//input[@placeholder = 'Search']"));

        public Menu(IWebDriver driver): base(driver) 
        {

        }
    }
}
