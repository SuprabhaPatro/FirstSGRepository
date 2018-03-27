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
    public class UpdateOtherInformationService
    {
        LoginPageElements pageElements = new LoginPageElements();
        LoginUpdateService updateService = new LoginUpdateService();
        UpdateOtherInformationElements updateOtherElemenets = new UpdateOtherInformationElements();

        
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();


        public void otherInformationLogin(IWebDriver driver)
        {
            //Use below code to get Global test data common for all test cases
            //string URL = testDataService.GetGlobalFieldValue("URL");

            updateService.InitialLogin(driver);

            string nameCheckbox = testDataService.GetFieldValue("checkbox name");

            switch (nameCheckbox)
            {
                case "instant games": updateOtherElemenets.instantGamesCheckBox.Check(driver);
                    break;

                case "contact me": updateOtherElemenets.contactMeCheckBox.Check(driver);
                    break;

                case "keno": updateOtherElemenets.kenoCheckBox.Check(driver);
                    break;

                case "lucky for life": updateOtherElemenets.luckyForLifeCheckBox.Check(driver);
                    break;

                case "mass cash": updateOtherElemenets.massCashCheckBox.Check(driver);
                    break;

                case "mega bucks": updateOtherElemenets.megabucksCheckBox.Check(driver);
                    break;

                case "mega millions": updateOtherElemenets.megaMillionsCheckBox.Check(driver);
                    break;
                    
                case "number game": updateOtherElemenets.numberGameCheckBox.Check(driver);
                    break;

                case "power ball": updateOtherElemenets.powerballCheckBox.Check(driver);
                    break;

                case "pull tab": updateOtherElemenets.pullTabCheckBox.Check(driver);
                    break;

                case "all or nothing": updateOtherElemenets.allOrNothingCheckBox.Check(driver);
                    break;
            
            }

            updateOtherElemenets.updateOtherInfoBtn.Click(driver);

            
            String messageExpected = testDataService.GetFieldValue("Message");
            IWebElement actualMessage = updateOtherElemenets.otherInformationCustElement(driver); //updateService.customizedFindElement(driver,"//*[@class ='alert alert-success']");
         
            Assert.AreEqual(messageExpected,actualMessage.Text);
            Thread.Sleep(5000);

        }

    }
}
