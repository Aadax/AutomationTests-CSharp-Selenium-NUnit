using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests
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
                Wait.Until(ExpectedConditions.PageLoaded);
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

        public IWebElement Find(By locator, int timeout = 30, bool validation = true)
        {
            if (validation)
            {
                Wait.Timeout = TimeSpan.FromSeconds(timeout);
                Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            return Driver.FindElement(locator);
        }

        public List<IWebElement> FindMany(By locator, int timeout = 30, bool validation = true)
        {
            if (validation)
            {
                Wait.Timeout = TimeSpan.FromSeconds(timeout);
                try
                {
                    Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                }
                catch (WebDriverTimeoutException) 
                {
                    return Driver.FindElements(locator).ToList();
                }
            }
            return Driver.FindElements(locator).ToList();
        }

        public void Cancel()
        {
            Wait.Timeout = TimeSpan.FromSeconds(30);
            Wait.Until(ExpectedConditions.LoaderDisappears);

            FindMany(By.XPath("ANULUJ"));

            Wait.Timeout = TimeSpan.FromSeconds(30);
            Wait.Until(ExpectedConditions.LoaderDisappears);
        }

        public void Next()
        {
            Wait.Timeout = TimeSpan.FromSeconds(30);
            Wait.Until(ExpectedConditions.LoaderDisappears);
            FindMany(By.XPath("NASTEPNY"));
        }

        public void WaitForElementToDisappear(By by, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));

            wait.Until(drv =>
            {
                try
                {
                    return !drv.FindElement(by).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }
    }
}