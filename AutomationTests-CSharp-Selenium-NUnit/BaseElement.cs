using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class BaseElement
    {
        protected readonly IWebElement Element;
        protected WebDriverWait Wait;
        protected readonly int ClickRetries = 3;

        public BaseElement(IWebElement element)
        {
            Element = element;
            Wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(5));
        }

        public IWebElement Find(By locator, bool validation = true, bool scroolMenu = false)
        {
            if (validation)
            {
                Wait.Until((d) =>
                {
                    try
                    {
                        if (scroolMenu)
                            ((IJavaScriptExecutor)GetDriver()).ExecuteScript("arguments[0].scrollTop += 200;", Element.FindElement(locator));

                        return Element.FindElements(locator).Count > 0;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            return Element.FindElement(locator);
        }

        public List<IWebElement> FindMany(By locator)
        {
            return Element.FindElements(locator).ToList();
        }

        public void JsClick()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("return arguments[0].click();", this.Element);
        }

        public void ScrollToQuarterPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetDriver();
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 4);");
        }

        public void SendKeys(string text)
        {
            Element.Clear();
            if (Element.GetAttribute("value") != string.Empty && Element.GetAttribute("value") != "0")
            {
                ClearByKeyboardKeys();
            }
            Element.SendKeys(text);
        }

        public void ClearByKeyboardKeys()
        {
            Element.SendKeys(Keys.LeftControl + "a");
            Element.SendKeys(Keys.Backspace);
        }

        protected IWebDriver GetDriver()
        {
            IWrapsDriver wrapsElement = Element as IWrapsDriver;
            return wrapsElement.WrappedDriver;
        }

        public void RetryClick(By locator, int ClickRetries = 3)
        {
            for (int i = 0; i < ClickRetries; i++)
            {
                try
                {
                    Find(locator).Click();
                    return;
                }
                catch (Exception e) when (e is ElementClickInterceptedException || e is StaleElementReferenceException)
                {
                    Thread.Sleep(300);
                }
            }
            throw new Exception($"Unable to click element: {locator} after {ClickRetries} attempts.");
        }

        //public void ScrollDown(string pixels = "150")
        //{
        //    IWebDriver driver = Element.GetDriver();
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    js.ExecuteScript($"window.scrollBy(0, {pixels})", "");
        //}

        //public void GetDriver()
        //{
        //    IWrapsDriver wrappedElement = Element as IWrapsDriver;
        //    if (wrappedElement == null)
        //    {
        //        FieldInfo fieldInfo = Element.GetType().GetField("underLyingElement", BindingFlags.NonPublic | BindingFlags.Instance);
        //        if (fieldInfo != null)
        //        {
        //            wrappedElement = fieldInfo.GetValue(Element) as IWrapsDriver;
        //            if (wrappedElement == null)
        //                throw new ArgumentException("Element must wrap a web driver");
        //        }
        //    }
        //}
    }
}