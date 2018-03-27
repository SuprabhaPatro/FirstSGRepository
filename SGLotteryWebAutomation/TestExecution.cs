using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using UnicornLibrary.Selenium.BaseClasses;
using UnicornLibrary.Unicorn.Utilities;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnicornLibrary.Unicorn.IServices;
using SGLotteryWebAutomation.Utilities;
using UnicornLibrary.Selenium.Services;
using UnicornLibrary.Unicorn.Factory;

namespace SGLotteryWebAutomation
{
    [TestFixture]
    public class TestExecution
    {
        ITestCaseService testCaseService = Factory.UnicornServices.GetTestCaseService();

        [ClassInitialize()]
        public void ClassInitialize()
        {
            // Runs this code once before any of your tests
        }

        [ClassCleanup()]
        public void ClassCleanUp()
        {
            // Runs this code once after all your tests are finished.
        }

        [Test]
        [Category("All")]
        [TestCaseSource("GetTestCases")]
        public void ExecuteTestCases(Tuple<String, long, long> testCase)
        {
            try
            {
                Console.WriteLine(testCase.Item1 + "," + testCase.Item2 + "," + testCase.Item3);
                testCaseService.ExecuteTestCase(testCase.Item1, testCase.Item2, testCase.Item3);
                Console.WriteLine("Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed");
                throw ex;
            }
        }

        public IEnumerable<Tuple<String, long, long>[]> GetTestCases()
        {
            Type thisType = typeof(TestExecution);
            Assembly currAssemble = thisType.Assembly;
            List<Tuple<String, long, long>> testCases = testCaseService.GetTestCases(currAssemble);

            foreach (var testCase in testCases)
            {
                yield return new[] { Tuple.Create(testCase.Item1, testCase.Item2, testCase.Item3) };
            }

        }

    }
}
