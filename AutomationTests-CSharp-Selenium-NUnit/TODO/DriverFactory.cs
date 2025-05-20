//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Remote;
//using OpenQA.Selenium;

//public static class DriverFactory
//{
//    public static IWebDriver CreateDriver()
//    {
//        string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "edge";
//        bool runOnGrid = Environment.GetEnvironmentVariable("RUN_ON_GRID") == "true";

//        if (runOnGrid)
//        {
//            var gridUrl = Environment.GetEnvironmentVariable("GRID_URL") ?? "http://localhost:4444";
//            var options = new EdgeOptions();
//            options.AcceptInsecureCertificates = true;

//            return new RemoteWebDriver(new Uri(gridUrl), options.ToCapabilities());
//        }
//        else
//        {
//            return new EdgeDriver(); // Albo ChromeDriver, zależnie od browser
//        }
//    }
//}
