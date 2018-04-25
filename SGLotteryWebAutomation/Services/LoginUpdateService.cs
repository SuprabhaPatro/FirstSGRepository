using SGLotteryWebAutomation.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices;
using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using UnicornLibrary.Selenium.BaseClasses;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SGLotteryWebAutomation.Services
{
    public class LoginUpdateService
    {
        LoginPageElements loginPageElements = new LoginPageElements();
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();


       // write customized functions here.
        public IWebElement customizedFindElement(IWebDriver driver , String xpathText)
        {
            IWebElement element = driver.FindElement(By.XPath(xpathText));
            return element;
        }


       // Function to fetch data from database
        public Dictionary<String, String> DataFromDB()
        {

            //return testDataService.GetFieldValue(DBName); 

            Dictionary<String , String> TestData = new Dictionary<String,String>();
            TestData.Add("firstName", testDataService.GetFieldValue("firstName"));
            TestData.Add("lastName", testDataService.GetFieldValue("lastName"));
            TestData.Add("City", testDataService.GetFieldValue("City"));
            TestData.Add("State", testDataService.GetFieldValue("State"));
            TestData.Add("Country", testDataService.GetFieldValue("Country"));
            TestData.Add("Address1", testDataService.GetFieldValue("Address1"));
            TestData.Add("Phone Number", testDataService.GetFieldValue("Phone Number"));
            TestData.Add("Message", testDataService.GetFieldValue("Message"));
            TestData.Add("typeCase", testDataService.GetFieldValue("typeCase"));
            TestData.Add("dobMonth", testDataService.GetFieldValue("dobMonth"));
            TestData.Add("dobDay", testDataService.GetFieldValue("dobDay"));
            TestData.Add("dobYear", testDataService.GetFieldValue("dobYear"));
            TestData.Add("zip code" , testDataService.GetFieldValue("zip code"));

            return TestData;
        }

        //Function to fetch global data from database
        public Dictionary<String, String> GlobalDataFromDB()
        {
            Dictionary<String, String> GlobalTestData = new Dictionary<String, String>();
            GlobalTestData.Add("username", testDataService.GetGlobalFieldValue("username"));
            GlobalTestData.Add("password", testDataService.GetGlobalFieldValue("password"));
            GlobalTestData.Add("URL", testDataService.GetGlobalFieldValue("URL"));

            return GlobalTestData;
            //return testDataService.GetGlobalFieldValue(DBvalueName);
        }

        //Function which carry outs inital login
        public void InitialLogin(IWebDriver driver)
        {
            Dictionary<String, String> GlobalTestData = new Dictionary<String, String>();
            GlobalTestData = GlobalDataFromDB();
           // driver.Navigate().GoToUrl("https://google.com");
         // driver.Navigate().GoToUrl("https://www.qts.uat.masslotteryplayersclub.com/login/index.php");
          driver.GoToURL(GlobalTestData["URL"]);
            loginPageElements.userNameTextBox.EnterText(driver, GlobalTestData["username"]);
            loginPageElements.passwordTextBox.EnterText(driver, GlobalTestData["password"]);
            loginPageElements.loginButton.Click(driver);


            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver web) =>
            {
                IWebElement element = loginPageElements.AccountLink.getWebElement(driver);
                if (element.Enabled)
                {
                    return true;
                }
                return false;
            });
            wait.Until(waitForElement);
            loginPageElements.AccountLink.Click(driver);
        }

        /// <summary>
        /// Function to enter general information 
        /// </summary>
        /// <param name="driver" value = "IWebdriver">  </param>
        /// <param name="TestData" value = "Dictionary of data fetched from database">  </param>
        public void  EnterGeneralInformation(IWebDriver driver, Dictionary<String,String> TestData)
        {

            loginPageElements.firstNameTextBox.ClearText(driver);
            loginPageElements.firstNameTextBox.EnterText(driver, TestData["firstName"]);
            loginPageElements.lastNameTextBox.ClearText(driver);
            loginPageElements.lastNameTextBox.EnterText(driver, TestData["lastName"]);
            loginPageElements.address1TextBox.ClearText(driver);
            loginPageElements.address1TextBox.EnterText(driver, TestData["Address1"]);
            loginPageElements.cityTextBox.ClearText(driver);
            loginPageElements.cityTextBox.EnterText(driver, TestData["City"]);
           
            (customizedFindElement(driver, "//*[@name='state']")).SendKeys(TestData["State"]);
            (customizedFindElement(driver, "//*[@name='country']")).SendKeys(TestData["Country"]);
            (customizedFindElement(driver, "//*[@name='dob_month']")).SendKeys(TestData["dobMonth"]);
            (customizedFindElement(driver, "//*[@name='dob_day']")).SendKeys(TestData["dobDay"]);
            (customizedFindElement(driver, "//*[@name='dob_year']")).SendKeys(TestData["dobYear"]);
           
            loginPageElements.zipTextBox.ClearText(driver);
            loginPageElements.zipTextBox.EnterText(driver, TestData["zip code"]);
            loginPageElements.phoneTextBox.ClearText(driver);
            loginPageElements.phoneTextBox.EnterText(driver, TestData["Phone Number"]);
            Thread.Sleep(5000);
            loginPageElements.updateGenInfoBtn.Click(driver);
            Thread.Sleep(5000);
   
        }

        //Main login function
        public void Login(IWebDriver driver)
        {
            Dictionary<String, String> TestData = new Dictionary<String, String>();
            TestData = DataFromDB();
            InitialLogin(driver);
            Console.WriteLine("After login");
            Thread.Sleep(500);
            EnterGeneralInformation(driver, TestData);
            String TypeCase = TestData["typeCase"];
            Console.WriteLine(TypeCase);
            String messInfo = TestData["Message"];
            IWebElement Msg = loginPageElements.CustomFindElement(TypeCase, driver);
            Assert.AreEqual(messInfo, Msg.Text);

        }


        public void getScreenShotWeb(IWebDriver driver, long testCaseId)
        {

            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            //Save the screenshot
            image.SaveAsFile(string.Format("D:\\screeshotsd_demo\\Screenshot{0}.Png", getcurrentTime() + " " + testCaseId), ScreenshotImageFormat.Jpeg);

        }
        public string getcurrentTime()
        {
            string currentTime = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            return currentTime;
        }
    
    }


}
