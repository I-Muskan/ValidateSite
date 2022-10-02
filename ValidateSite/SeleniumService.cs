using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidateSite
{
    public class SeleniumService
    {

        static IWebDriver driver;

        public string seleniumScreenShot(string url)
        {
            //ChromeOptions options = new ChromeOptions(); 
            ////options.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1200", "-window-position = -9999, 0", "--no-startup-window", "--ignore-certificate-errors", "--disable-extensions", "--no-sandbox", "--disable-dev-shm-usage");

            //options.AddArguments(new List<string>() { "no-sandbox", "headless", "disable-gpu" });

            var chromeDriverService = ChromeDriverService.CreateDefaultService(@"C:\Users\muskan.2\Downloads\Spakthon2022-Team56-HTML (1)\Spakthon2022-Team56-HTML\ValidateSite\DriverChrome");
            chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() {
                    "--silent-launch",
                    "--no-startup-window",
                    "no-sandbox",
                    "headless",
            "-window-position = -9999, 0"});

           
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            //driver = new ChromeDriver(Environment.CurrentDirectory);



            // DriverService with Path to driver.exe
            //ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\_MT5_TOOLS\DRIVER\CHROME");
            //// hide driver Console? true/false 
            //service.HideCommandPromptWindow = true;

            //// change Standard-Download-Path
            //ChromeOptions options = new ChromeOptions();
            //var downloadDirectory = GlobalVars.RootPath + @"Pool\" + GlobalVars.strSymbol + @"\" + GlobalVars.strSymbol + @"_" + GlobalVars.strPeriod;
            //options.AddUserProfilePreference("download.default_directory", downloadDirectory);
            //options.AddUserProfilePreference("download.prompt_for_download", false);
            //options.AddUserProfilePreference("disable-popup-blocking", "true");

            //// Selenium Driver starten:
            //webdriver = new ChromeDriver(service, options);


            var weburl = url;
            driver.Url = weburl;
            var title="";
            //driver.Navigate().GoToUrl(weburl);
            try
            {
                //System.Threading.Thread.Sleep(4000);
                Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string imagePath = "Dataset/selenium-screenshot.png";
                TakeScreenshot.SaveAsFile(imagePath);
                title = driver.Title;
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            return title;
            driver.Quit();
        }


    }
}
