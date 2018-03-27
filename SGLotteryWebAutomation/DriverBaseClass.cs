using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;
using UnicornLibrary.Unicorn.Services;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;

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
            driver = new ChromeDriver();

            //to use IE as default browser for all test cases
           //driver = this.IntializeIE();


            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--disable-extensions");
          //  driver = new ChromeDriver();//options);

            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("https://google.com");
            }


    }
}
