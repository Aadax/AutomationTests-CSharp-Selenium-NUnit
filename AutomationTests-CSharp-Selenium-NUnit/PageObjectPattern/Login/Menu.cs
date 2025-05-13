using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern
{
    public class Menu : BasePage
    {
        public IWebElement Search => Find(By.XPath(""));

        public Menu(IWebDriver driver): base(driver) 
        {

        }
    }
}
