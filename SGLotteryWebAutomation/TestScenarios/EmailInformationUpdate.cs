﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornLibrary.Unicorn.Utilities;
using UnicornLibrary.Unicorn.Services;
using OpenQA.Selenium;
using SGLotteryWebAutomation.Utilities;
using SGLotteryWebAutomation.Services;

namespace SGLotteryWebAutomation.TestScenarios
{
    [UnicornAttributes.ExecuteTestCase(UnicornEnums.ExecuteType.Execute)]
    [UnicornAttributes.Module((int)Modules.Login)]
    [UnicornAttributes.TestCasePriority(UnicornEnums.Priority.Priority1)]
    public class EmailInformationUpdate : DriverBaseClass
    {
        //int myVariable1 = 0;


        //LoginService loginService = new LoginService();
        EmailUpdateService LoginInitial = new EmailUpdateService();
        //UpdateService updateService = new UpdateService();

        override public void Execute(long testScenarioId, long testCaseId, string testCaseName)
        {
            InitDriver();
            LoginInitial.LoginEmail(driver);
           // updateService.Update(driver);
        }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            List<Tuple<bool, string, int>> errors = new List<Tuple<bool, string, int>>();

            //errors.Add(Tuple.Create(false, "errormessage", 1));
            //errors.Add(Tuple.Create(false, "errormessage", 2));
            //errors.Add(Tuple.Create(true, "", 2));
            //if (myVariable1 == 2)
            //{
            //    //
            //}
            return errors;
        }
    }
}
