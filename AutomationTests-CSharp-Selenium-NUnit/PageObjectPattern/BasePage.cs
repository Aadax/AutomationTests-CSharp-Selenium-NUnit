using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        public BasePage(IWebDriver driver, bool validation = true)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            if (validation)
            {
                Wait.Until(ExpectedConditions.PageLoaded);
            }
        }

        //public void EnterText(By locator, string text)
        //{
        //    Driver.FindElement(locator).Clear();
        //    Driver.FindElement(locator).SendKeys(text);
        //}

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

        public void WaitForLoaderToDisappear(By loaderLocator, int timeout = 10)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout))
                .Until(driver => !driver.FindElements(loaderLocator).Any(e => e.Displayed));
        }


        public void ScrollToElement(By locator)
        {
            IWebElement element = Find(locator, 30, true);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void WaitUntil(Func<IWebDriver, bool> condition, int timeout = 30)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout)).Until(condition);
        }

    }
}