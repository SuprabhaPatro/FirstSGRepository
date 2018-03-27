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
    public class PasswordUpdateService
    {
        PasswordUpdateElements passwordPageElements = new PasswordUpdateElements();
        LoginPageElements LoginPageElements = new LoginPageElements();


        LoginUpdateService loginservice = new LoginUpdateService();
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        public void Login(IWebDriver driver)
        {


            loginservice.InitialLogin(driver);
            
            Thread.Sleep(5000);
        }
        /// <summary>
        /// This Method is used to verify the updation of password
        /// </summary>
        /// <param name="driver"></param>
        public void LoginUpdatePAss(IWebDriver driver)
        {
            //Use below code to get Global test data common for all test cases
            //string URL = testDataService.GetGlobalFieldValue("URL");
            Login(driver);
            LoginPageElements.AccountLink.Click(driver);
            Thread.Sleep(5000);

     
            String newPassword = testDataService.GetFieldValue("password");
            String confirmPassword =  testDataService.GetFieldValue("confirmPassword");


            passwordPageElements.passwordTextBox.EnterText(driver, newPassword);
            passwordPageElements.passwordConfirmTextBox.EnterText(driver, confirmPassword);
            passwordPageElements.updatePasswordButton.Click(driver);
            Thread.Sleep(5000);

           
            IWebElement PasswordInfoMsg = driver.FindElement(By.XPath(passwordPageElements.verifyPassTextXpath));
            
            string message = testDataService.GetFieldValue("Message");
            Assert.AreEqual(message, PasswordInfoMsg.Text);



        }

    }
}
