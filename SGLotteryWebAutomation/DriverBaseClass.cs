using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;
using UnicornLibrary.Unicorn.Services;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SGLotteryWebAutomation
{
    public abstract class DriverBaseClass : TestScenarioBaseClass
    {
        public IWebDriver driver;
        public AppiumDriver<IWebElement> appdriver;
        public Window window;

        public void InitDriver()
        {
            //to use Firefox as default browser for all test cases
            //driver = this.IntializeFirefox();
           
            //to use Chrome as default browser for all test cases
            //driver = this.IntializeChrome();
            
            //to use IE as default browser for all test cases
            //driver = this.IntializeIE();

            //chrome initialization
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            //options.BinaryLocation = @"C:\Users\suprabha.patro\Desktop\chrome64_56.0.2924.87\chrome.exe";
            options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            options.AddArguments("test-type");
            options.AddArguments("start-maximized");
            options.AddArguments("--enable-automation");
            options.AddArguments("test-type=browser");
            options.AddArguments("disable-infobars");
            //options.AddArguments("--no-sandbox"); C:\Program Files (x86)\Google\Chrome\Application
            driver = new ChromeDriver(options); 
          
            //firefox intialization
      
            /*FirefoxOptions foxOptions = new FirefoxOptions();
            //foxOptions.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            TimeSpan time = TimeSpan.FromSeconds(10);
            FirefoxDriver driver = new FirefoxDriver(service,foxOptions,time);  */
             
            driver.Manage().Window.Maximize();
          //  driver.Navigate().GoToUrl("https://www.qts.uat.masslotteryplayersclub.com/login/index.php");
           }


    }
}
