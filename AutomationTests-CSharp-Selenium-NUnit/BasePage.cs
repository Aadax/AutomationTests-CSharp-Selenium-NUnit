using Docker.DotNet.Models;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        private IWebElement test => Find(By.XPath("XYZ"));
        private IWebElement loginButtonAuthorize => Find(By.XPath(".//span[@class = 'test' and text() = 'test']"));


        public BasePage(IWebDriver driver, bool validation = true)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            if (validation)
            {
                //Wait.Until(ExpectedConditions.PageLoaded);
            }
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
        public void TestMethod()
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
            Driver.FindElement(locator).Clear();
            Driver.FindElement(locator).SendKeys(text);
        }

        public void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        public void WaitForElementVisible(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool IsElementDisplayed(By locator, int timeoutInSeconds)
        {
            return true;
        }

        public string GetElementAttribute(By locator, string attributeName)
        {
            return "";
        }

        public IWebElement Find(By locator)
        {
            return Driver.FindElement(locator);
        }
    }
}