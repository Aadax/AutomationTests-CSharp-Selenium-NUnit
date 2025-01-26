using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage() 
        {
            this.driver = driver;
        }

        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        { 
        }  

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown() 
        {
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            
        }

        public void EnterText(By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void WaitForElementVisible(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool IsElementDisplayed(By locator, int timeoutInSeconds)
        {
            return true;
        }

        public string GetElementAttribute(By locator, string attributeName)
        {
            return "";
        }
    }
}