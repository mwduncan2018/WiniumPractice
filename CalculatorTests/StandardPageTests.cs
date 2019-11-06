using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorAutomationFramework.POM;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class StandardPageTests
    {
        [AssemblyInitialize] // Executes once before the test run
        public static void BeforeEntireTestRun(TestContext context){}
        [AssemblyCleanup] // Executes once after the test run
        public static void AfterEntireTestRun(){}


        [ClassInitialize]
        public static void BeforeTestClass(TestContext context)
        {
            CalcDriver.Start();
        }
        [ClassCleanup]
        public static void AfterTestClass()
        {
            CalcDriver.Shutdown();
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
        }
        [TestCleanup]
        public void AfterEachTest()
        {
            try
            {
                StandardPage.ClearHistory();
            }
            catch {}
        }

        [TestMethod]
        public void VerifyNavigationToTheStandardPage()
        {
            StandardPage.GoTo();
            Assert.IsTrue(StandardPage.VerifyIsAt());
        }
        [TestMethod]
        public void VerifyEmptyHistoryOnTheStandardPage()
        {
            StandardPage.GoTo();
            Assert.IsTrue(StandardPage.VerifyEmptyHistory());
        }
        [TestMethod]
        public void VerifyStandardPageAddition()
        {
            // Given
            StandardPage.GoTo();
            StandardPage.ClickButton3();
            StandardPage.ClickButtonPlus();
            StandardPage.ClickButton5();

            // When
            StandardPage.ClickButtonEquals();

            // Then
            Assert.IsTrue(StandardPage.VerifyResultIs(8));
        }
        [TestMethod]
        public void VerifyStandardPageWithSeveralAdditionOperations()
        {
            // Given
            StandardPage.GoTo();
            StandardPage.ClickButton3();
            StandardPage.ClickButtonPlus();
            StandardPage.ClickButton5();
            StandardPage.ClickButtonEquals();

            StandardPage.ClickButton3();
            StandardPage.ClickButtonPlus();
            StandardPage.ClickButton3();

            // When
            StandardPage.ClickButtonEquals();

            // Then
            Assert.IsTrue(StandardPage.VerifyResultIs(6));
        }


    }
}
