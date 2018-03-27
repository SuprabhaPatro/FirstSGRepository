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
    public class PasswordUpdateElements
    {
        public ISeleniumTextBoxService passwordTextBox = Factory.ElementServices.GetWebTextBox("xpath", "//*[@name = 'password']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumTextBoxService passwordConfirmTextBox = Factory.ElementServices.GetWebTextBox("xpath", "//*[@name = 'confirm_password']", UnicornEnums.WebTextBoxControl.WebTextBox);
       // public ISeleniumCheckBoxService remembeMeCheckBox = Factory.ElementServices.GetWebCheckBox("id", "MainContent_remember");
        public ISeleniumButtonService updatePasswordButton = Factory.ElementServices.GetWebButton("xpath", "//*[@value = 'Update Password']");
        public String verifyPassTextXpath = " //*[@class = 'alert alert-danger']";

    }
}
