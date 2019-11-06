using System;
using CalculatorAutomationFramework.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class ScientificPageTests
    {
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
                ScientificPage.ClearHistory();
            }
            catch { }
        }

        [TestMethod]
        public void VerifyNavigationToTheScientificPage()
        {
            ScientificPage.GoTo();
            Assert.IsTrue(ScientificPage.VerifyIsAt());
        }

    }
}
