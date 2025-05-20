using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests_CSharp_Selenium_NUnit.PageObjectPattern.MainPage
{
    public class MainPage : BaseElement
    {
        private Admin Admin => new(Find(By.XPath(".//span[text() = 'Admin']")));

        private Buzz Buzz => new(Find(By.XPath(".//span[text() = 'Buzz']")));

        private Claim Claim => new(Find(By.XPath(".//span[text() = 'Claim']")));

        private Dashboard Dashboard => new(Find(By.XPath(".//span[text() = 'Dashboard']")));

        private Directory Directory => new(Find(By.XPath(".//span[text() = 'Directory']")));

        private Leave Leave => new(Find(By.XPath(".//span[text() = 'Leave']")));

        private Maintenance Maintenance => new(Find(By.XPath(".//span[text() = 'Maintenance']")));

        private MyInfo MyInfo => new(Find(By.XPath(".//span[text() = 'My Info']")));

        private Performance Performance => new(Find(By.XPath(".//span[text() = 'Performance']")));

        private PIM PIM => new(Find(By.XPath(".//span[text() = 'PIM']")));

        private Recruitment Recruitment => new(Find(By.XPath(".//span[text() = 'Recruitment']")));

        private Time Time => new(Find(By.XPath(".//span[text() = 'Time']")));

        public MainPage(IWebElement element) : base(element) 
        {
            new Actions(GetDriver()).MoveToElement(element).Perform();
            Wait.Until(ExpectedConditions.ElementNotChanging(element));
        }

        public void AdminJsClick() => Admin.JsClick();

        public void BuzzJsClick() => Buzz.JsClick();

        public void ClaimJsClick() => Claim.JsClick();

        public void DashboardJsClick() => Dashboard.JsClick();

        public void DirectoryJsClick() => Directory.JsClick();

        public void LeaveJsClick() => Leave.JsClick();

        public void MaintenanceJsClick() => Maintenance.JsClick();

        public void MyInfoJsClick() => MyInfo.JsClick();

        public void PerformanceJsClick() => Performance.JsClick();

        public void PIMJsClick() => PIM.JsClick();

        public void RecruitmentJsClick() => Recruitment.JsClick();

        public void TimeJsClick() => Time.JsClick();
    }
}