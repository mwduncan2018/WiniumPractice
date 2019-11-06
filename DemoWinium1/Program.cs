using CalculatorAutomationFramework.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace DemoWinium1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SandboxMethods.Main02();
        }
    }

    public static class SandboxMethods
    {
        /// <summary>
        /// Testing with straight Winium commands
        /// </summary>
        public static void Main01()
        {
            var calc = new Winium.Cruciatus.Application("C:/windows/system32/calc.exe");
            calc.Start();

            var winFinder = By.Name("Calculator").AndType(ControlType.Window);
            var win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);

            win.FindElementByName("Open Navigation").Click();
            win.FindElementByName("Scientific Calculator").Click();

            win.FindElementByName("Seven").Click();
            win.FindElementByUid("multiplyButton").Click();
            win.FindElementByName("Three").Click();
            win.FindElementByUid("equalButton").Click();

            var x = win.FindElementByUid("CalculatorResults").ToString();
            Console.WriteLine(x.ToString());

            Console.ReadKey();
            win.FindElement(By.Uid("Close")).Click();
        }

        /// <summary>
        /// Testing with a Page-Object Model
        /// Winium commands are located inside the classes that implement the Page-Object Model
        /// </summary>
        public static void Main02()
        {
            // Start the Calc app
            // Navigate to the Scientific page
            // Verify the history is empty (because no operations have taken place yet)
            CalcDriver.Start();
            ScientificPage.GoTo();
            var result = ScientificPage.VerifyEmptyHistory() ? "pass" : "fail";
            Console.WriteLine("The test result is " + result);

            // Navigate to the Standard page
            // Add 2 and 3
            // Verify the result is 5
            StandardPage.GoTo();
            StandardPage.ClickButton3();
            StandardPage.ClickButtonPlus();
            StandardPage.ClickButton5();
            result = StandardPage.VerifyResultIs(8) ? "pass" : "fail";
            Console.WriteLine("The test result is " + result);

            Console.ReadKey();
            CalcDriver.Shutdown();
        }

    }

}
