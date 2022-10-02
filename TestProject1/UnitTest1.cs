using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using ValidateSite;
using ValidateSite.SiteService;
using Xunit;

namespace TestProjectXunit
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            _validSite = new ValidateSites();
        }

        private readonly IValidateSite _validSite;
        [Fact]
        public void Screenshot()
        {
            //ValidateSites validateSite = new ValidateSites();
            string url = _validSite.getUrl();

            IWebDriver driver = new FirefoxDriver();
            driver.Url = url;
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }
    }
}