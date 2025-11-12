using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;


namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class Base
    {
        protected IWebDriver Driver;
        private Stopwatch Stopwatch;
        //private string browserMachineName;

        protected readonly string Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public Base() { }

        //[OneTimeSetUp]
        //public void PrepareDriver()
        //{
        //    //if (!Debugger.IsAttached);
        //        //FeedWithUnresolved();

        //    EdgeOptions opt = new EdgeOptions
        //    {
        //        Proxy = new Proxy
        //        {
        //            //SslProxy = ""; 
        //            //HttpProxy = ;
        //        }
        //    };

        //    EdgeOptions EdgeOptions = new EdgeOptions();

        //    EdgeOptions.AcceptInsecureCertificates = true;

        //    if (Environment.GetEnvironmentVariable("JOB_NAME") != null || new ConfigurationBuilder().AddJsonFile(Path.Combine(GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "/appsettings.json").Build().GetValue<bool>("RUNONGRID"))
        //    {

        //    }
        //}

        [SetUp]
        public void Prepare()
        {
            Stopwatch = Stopwatch.StartNew();
            var options = new ChromeOptions();

            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);
        }

        [TearDown]
        public void FinishTest()
        {
            Stopwatch.Stop();

            try
            {
                Driver?.Quit();
                Driver?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error while closing browser: {ex.Message}");
            }
        }
    }
}