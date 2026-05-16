using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace MyProject.Steps
{
    [Binding]
    public class LaunchChromeSteps
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        [Given(@"I launch the Chrome browser")]
        public async Task GivenILaunchTheChromeBrowser()
        {
            _playwright = await Playwright.CreateAsync();
            // Launch Chromium (which powers Google Chrome). Headless is set to false to make it visible.
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, 
                Channel = "chrome" // Forces Playwright to use installed Google Chrome instead of Chromium
            });
            _page = await _browser.NewPageAsync();
        }

        [When(@"I navigate to ""(.*)""")]
        public async Task WhenINavigateTo(string url)
        {
            await _page.GotoAsync(url);
        }

        [Then(@"I should see the page title contains ""(.*)""")]
        public async Task ThenIShouldSeeThePageTitleContains(string expectedTitle)
        {
            string title = await _page.TitleAsync();
            Assert.Contains(title, expectedTitle);
        }

        [Then(@"I close the browser")]
        public async Task ThenICloseTheBrowser()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
