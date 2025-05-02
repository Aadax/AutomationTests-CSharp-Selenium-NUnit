using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests
{
    public class BaseElement
    {
        protected readonly IWebElement Element;
        protected WebDriverWait Wait;

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
    }
}
