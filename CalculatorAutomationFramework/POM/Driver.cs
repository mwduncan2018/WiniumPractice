using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace CalculatorAutomationFramework.POM
{
    public class CalcDriver
    {
        private static string calculatorPath = @"C:/windows/system32/calc.exe";
        public static Winium.Cruciatus.Elements.CruciatusElement Instance = null;

        private static By CLOSE_CALCULATOR = By.Uid("Close");

        public static void Start()
        {
            if (Instance is null)
            {
                var calculatorApplication = new Winium.Cruciatus.Application("C:/windows/system32/calc.exe");
                calculatorApplication.Start();
                Instance = Winium.Cruciatus.CruciatusFactory.Root
                    .FindElement(By.Name("Calculator").AndType(ControlType.Window));
            }
        }

        public static void Shutdown()
        {
            Instance.FindElement(CLOSE_CALCULATOR).Click();
        }

    }
}
