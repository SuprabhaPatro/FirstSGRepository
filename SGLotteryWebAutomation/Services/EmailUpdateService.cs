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

namespace SGLotteryWebAutomation.Services
{
    public class EmailUpdateService
    {
        LoginPageElements pageElements = new LoginPageElements();
        LoginUpdateService loginUpateService = new LoginUpdateService();
        EmailInformationUpdatePageElements pageelem = new EmailInformationUpdatePageElements();
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        public void LoginEmail(IWebDriver driver)
        {
            //Use below code to get Global test data common for all test cases
            //string URL = testDataService.GetGlobalFieldValue("URL");
            
            loginUpateService.InitialLogin(driver);
            string message = testDataService.GetFieldValue("Message");    
         
            string email = testDataService.GetFieldValue("email");
            string confirmEmail = testDataService.GetFieldValue("confirmEmail");

            pageelem.newEmailTextBox.EnterText(driver, email);
            pageelem.newEmailConfirmTextBox.EnterText(driver, confirmEmail);
            pageelem.updateEmailInfoBtn.Click(driver);
            Thread.Sleep(5000);

            IWebElement successEmailInfo = driver.FindElement(By.XPath("//*[@class='alert alert-success']"));

            Assert.AreEqual(message, successEmailInfo.Text);

        }

    }
}
