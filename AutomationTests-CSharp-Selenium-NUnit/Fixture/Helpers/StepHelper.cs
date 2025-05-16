using NUnit.Framework;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public static class StepHelper
    {
        public static void Step(string message)
        {
            TestContext.Progress.WriteLine(message);
        }
    }
}