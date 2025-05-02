using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests
{
    public sealed class ExpectedConditions
    {
        private ExpectedConditions() { }

        public static Func<IWebDriver,IWebElement>ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    return ElementIfVisible(driver.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }

        public static bool ElementExists(By locator, IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(PageLoaded);
                return driver.FindElement(locator).Displayed;
            }
            catch 
            {
                return false;
            }
        }

        public static bool ElementExist(By locator, IWebDriver driver)
        {
            try
            {
                return driver.FindElements(locator).All(x => x.Displayed);
            }
            catch
            {
                return false;
            }
        }

        public static bool ElementIsNotEditable(IWebElement element, string value = "Test")
        {
            try
            {
                element.SendKeys(value);
                return false;
            }
            catch (ElementNotInteractableException) 
            {
                return false;
            }
        }

        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = ElementIfVisible(driver.FindElement(locator));
                    if (element != null && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        private static IWebElement ElementIfVisible(IWebElement element) 
        {
            return (element.Displayed && element.Enabled) ? element : null;
        }

        public static Func<IWebDriver, bool> PageLoaded = (Driver) =>
        {
            var jsExec = (IJavaScriptExecutor)Driver;
            try
            {
                if (Driver.PageSource.Contains("ant-select-item-option-content")
                || Driver.PageSource.Contains("cssgridlegacy") || Driver.PageSource.Contains("ltr no-js")
                || Driver.Url.Contains("sso")) //if React
                    
                return (string)(jsExec).ExecuteScript("return document.readyState;") == "complete";
                    
                return (long)(jsExec).ExecuteScript("return jQuery.active;") == 0 && (string)(jsExec).ExecuteScript("return document.readyState;") == "complete";
            }
            catch
            {
                return false;
            }
        };

        public static Func<IWebDriver, bool> LoaderDisappears = (Driver) =>
        {
            try
            {
                //TO IMPLEMENT LOCATOR
                return !Driver.FindElements(By.XPath("TEST")).Any(q => q.Displayed);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };

        public static Func<IWebDriver, IWebElement> ElementNotChanging(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    var Size = element.Size;
                    var Text = element.Text;
                    Thread.Sleep(50);

                    if (element.Size == Size  && element.Text == Text)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

    }
}
