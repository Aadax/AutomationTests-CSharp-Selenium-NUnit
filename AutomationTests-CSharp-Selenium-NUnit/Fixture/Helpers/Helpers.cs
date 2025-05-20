using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;

namespace AutomationTests_CSharp_Selenium_NUnit
{
    public static class Helpers
    {
        private static Dictionary<string, string> Urls;

        public static void Step(string message)
        {
            TestContext.Progress.WriteLine(message);
        }

        private static string FindJsonFile(string relativePath)
        {
            var currentDir = AppDomain.CurrentDomain.BaseDirectory;

            while (!string.IsNullOrEmpty(currentDir))
            {
                var candidate = Path.Combine(currentDir, relativePath);

                if (File.Exists(candidate))
                    return candidate;

                // Cofnij się wyżej w drzewie katalogów
                currentDir = Directory.GetParent(currentDir)?.FullName;
            }

            throw new FileNotFoundException($"❌ Nie znaleziono pliku JSON pod ścieżką względną: {relativePath}");
        }


        private static void EnsureUrlsLoaded()
        {
            if (Urls != null) return;

            var jsonPath = FindJsonFile(Path.Combine("Fixture", "DataModels", "Urls.json"));

            var jsonContent = File.ReadAllText(jsonPath);
            Urls = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
        }


        public static void AssertCurrentUrl(IWebDriver driver, string expectedUrlOrKey, int timeoutInSeconds = 5)
        {
            EnsureUrlsLoaded();
            // Jeśli klucz istnieje w JSON, traktujemy jako alias do urla
            var actualExpectedUrl = Urls.TryGetValue(expectedUrlOrKey, out var resolvedUrl)
                ? resolvedUrl
                : expectedUrlOrKey;

            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(d => d.Url == actualExpectedUrl);

            Assert.That(driver.Url, Is.EqualTo(actualExpectedUrl),
                $"❌ Expected: {actualExpectedUrl}, but was: {driver.Url}");
        }
    }
}