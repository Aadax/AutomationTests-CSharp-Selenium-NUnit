using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Diagnostics;


namespace AutomationTests_CSharp_Selenium_NUnit
{
    public class Base
    {
        protected IWebDriver Driver;
        private Stopwatch Stopwatch;
        private string browserMachineName;

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
            Driver = new EdgeDriver();
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
                Console.WriteLine($"❌ Error closing browser: {ex.Message}");
            }
        }

        //[OneTimeTearDown]
        //public void Finish()
        //{
        //    Driver?.Quit();
        //}
    }
}