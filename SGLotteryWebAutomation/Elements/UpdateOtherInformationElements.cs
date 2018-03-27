using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using UnicornLibrary.Unicorn.Utilities;

namespace SGLotteryWebAutomation.Elements
{
    public class UpdateOtherInformationElements
    {
      

        public ISeleniumCheckBoxService contactMeCheckBox = Factory.ElementServices.GetWebCheckBox("id", "research_optin"); //TC_049

        public ISeleniumCheckBoxService megaMillionsCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_mega_millions"); //TC_050

        public ISeleniumCheckBoxService instantGamesCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_instant_games"); // TC_051

        public ISeleniumCheckBoxService powerballCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_powerball"); // TC_052
        public ISeleniumCheckBoxService megabucksCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_megabucks_doubler"); //TC_053
        public ISeleniumCheckBoxService kenoCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_keno"); //TC_054


        public ISeleniumCheckBoxService allOrNothingCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_all_or_nothing"); //TC_)55
        public ISeleniumCheckBoxService luckyForLifeCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_lucky_for_life"); // TC_056
        public ISeleniumCheckBoxService pullTabCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_pull_tab"); //TC_057
        public ISeleniumCheckBoxService numberGameCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_numbers_game"); //TC_058

        public ISeleniumCheckBoxService massCashCheckBox = Factory.ElementServices.GetWebCheckBox("id", "fav_mass_cash"); //TC_059



        public ISeleniumButtonService updateOtherInfoBtn = Factory.ElementServices.GetWebButton("xpath", "//*[@value ='Update Info']");




        // function to fetch the label where message is displayed.
        public IWebElement otherInformationCustElement(IWebDriver driver) {

            return driver.FindElement(By.XPath("//*[@class ='alert alert-success']"));
        
        
        }

    }
}
