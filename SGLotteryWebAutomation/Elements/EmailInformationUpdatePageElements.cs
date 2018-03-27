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
    public class EmailInformationUpdatePageElements
    {


        public ISeleniumTextBoxService newEmailTextBox = Factory.ElementServices.GetWebTextBox("id", "new_email", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumTextBoxService newEmailConfirmTextBox = Factory.ElementServices.GetWebTextBox("id", "confirm_email", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumButtonService updateEmailInfoBtn = Factory.ElementServices.GetWebButton("xpath", "//*[@value='Update Email Info']");

        
    }
}
