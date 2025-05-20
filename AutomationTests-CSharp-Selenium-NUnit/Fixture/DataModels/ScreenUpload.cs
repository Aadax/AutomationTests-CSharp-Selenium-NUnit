using OpenQA.Selenium;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class ScreenUpload
    {
        private const string SCREENSHOT_FOLDER = @"";
        private const string SCREENSHOT_ADDRESS = @"TEST";
        string folder = Path.Combine(SCREENSHOT_FOLDER, DateTime.Now.ToString("yyyyMMdd"));
        //Directory.CreateDirectory(folder);

        private string screenshot;

        public ScreenUpload(IWebDriver driver)
        {
            screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }

        public string getLinkOfUploadedFile()
        {
            string fileName = Guid.NewGuid().ToString() + ".png";
            string fullPath = Path.Combine(folder, fileName);
            File.WriteAllBytes(fullPath, Convert.FromBase64String(screenshot));

            return SCREENSHOT_ADDRESS + fileName;
        }
    }
}
