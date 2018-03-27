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
    public class LoginPageElements
    {
        public ISeleniumTextBoxService userNameTextBox = Factory.ElementServices.GetWebTextBox("name", "email", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumTextBoxService passwordTextBox = Factory.ElementServices.GetWebTextBox("name", "password", UnicornEnums.WebTextBoxControl.WebTextBox);
       // public ISeleniumCheckBoxService remembeMeCheckBox = Factory.ElementServices.GetWebCheckBox("id", "MainContent_remember");
        public ISeleniumButtonService loginButton = Factory.ElementServices.GetWebButton("xpath", "//*[@class = 'btn btn-primary btn-block']");
    
        public ISeleniumHyperlinkService AccountLink  = Factory.ElementServices.GetHyperLinkService("xpath", "//*[@id='primary-nav']/li[1]/a" );

        public ISeleniumTextBoxService firstNameTextBox = Factory.ElementServices.GetWebTextBox("id", "first_name", UnicornEnums.WebTextBoxControl.WebTextBox);
      
        public ISeleniumTextBoxService lastNameTextBox = Factory.ElementServices.GetWebTextBox("id", "last_name", UnicornEnums.WebTextBoxControl.WebTextBox);
        //public ISeleniumTextBoxService userNameTextBox = Factory.ElementServices.GetWebTextBox("name", "email", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumTextBoxService address1TextBox = Factory.ElementServices.GetWebTextBox("id", "address1", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumTextBoxService address2TextBox = Factory.ElementServices.GetWebTextBox("id", "address2", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumTextBoxService cityTextBox = Factory.ElementServices.GetWebTextBox("id", "city", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumTextBoxService zipTextBox = Factory.ElementServices.GetWebTextBox("id", "zip", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumTextBoxService phoneTextBox = Factory.ElementServices.GetWebTextBox("id", "phone", UnicornEnums.WebTextBoxControl.WebTextBox);

        public ISeleniumButtonService updateGenInfoBtn = Factory.ElementServices.GetWebButton("xpath", "//*[@value='Update General Info']");

        public ISeleniumCheckBoxService ageVerifyCheckBox = Factory.ElementServices.GetWebCheckBox("id", "age_verify");
       // public ISeleniumDropDownService dobMonth = Factory.ElementServices.GetWebDropdown ("xpath", "//*[@name='dob_month']", UnicornEnums.WebDropDownControl.WebSelectBoxItReadOnlyDropDown);


        public IWebElement CustomFindElement(string type, IWebDriver driver)
        {
            if (type == "Invalid")
            {
                IWebElement Msg = driver.FindElement(By.XPath("//*[@class = 'alert alert-success']"));
                Console.WriteLine(Msg.Text);
                return Msg;
            }
            else
            {
                if ((driver.FindElement(By.XPath("//*[@id='content']/div/div/div/form[1]/div/div[2]/div[1]/p"))).Displayed)
                {
                    IWebElement Msg = driver.FindElement(By.XPath( "//*[@id='content']/div/div/div/form[1]/div/div[2]/div[1]/p")); 
                    return Msg;
                }
                else
                {
                    IWebElement Msg = driver.FindElement(By.XPath( "//*[@class = 'alert alert-success']"));
                    return Msg;
                }

            }
        }
    
    
    }
}
