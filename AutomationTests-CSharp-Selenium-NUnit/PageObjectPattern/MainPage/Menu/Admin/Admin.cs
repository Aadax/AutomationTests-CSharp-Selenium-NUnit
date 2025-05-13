using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class Admin : BaseElement
    {
        public UserManagement UserManagement => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//span[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'User Management')]")));

        public Job Job => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//span[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'Job')]")));

        public Organization Organition => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//span[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'Organization')]")));

        public Qualifications Qualifications => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//span[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'Qualifications')]")));
        
        public Nationalities Nationalities => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//a[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'Nationalities')]")));
        
        public CorporateBranding CorporateBranding => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//a[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'Corporate Branding')]")));
        
        public Configuration Configuration => new(Find(By.XPath("//*[@aria-label = 'Topbar Menu']//span[@class = 'oxd-topbar-body-nav-tab-item' and contains(text(), 'Configuration')]")));

        public Admin(IWebElement element) : base(element)
        {
            new Actions(GetDriver()).MoveToElement(element).Perform();
            Wait.Until(ExpectedConditions.ElementNotChanging(element));
        }
    }
}
