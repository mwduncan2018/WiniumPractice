using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Elements;
using Winium.Cruciatus.Extensions;

namespace CalculatorAutomationFramework.POM
{
    public class StandardPage : BasePage
    {
        private static readonly By HEADER = By.Uid(@"Header");
        private static readonly By HAMBURGER_MENU_ICON = By.Uid(@"TogglePaneButton");
        private static readonly By STANDARD_MENU_OPTION = By.Uid(@"Standard");

        private static readonly By HISTORY_EMPTY = By.Uid(@"HistoryEmpty");
        private static readonly By HISTORY_LABEL = By.Uid(@"HistoryLabel");
        private static readonly By BTN_CLEAR_HISTORY = By.Uid(@"ClearHistory");

        private static readonly By CALCULATOR_RESULTS = By.Uid(@"CalculatorResults");
        private static readonly By RESULT_TEXT_BLOCK = By.Uid(@"ResultTextBlock");
     
        private static readonly By BTN_1 = By.Uid(@"num1Button");
        private static readonly By BTN_2 = By.Uid(@"num2Button");
        private static readonly By BTN_3 = By.Uid(@"num3Button");
        private static readonly By BTN_4 = By.Uid(@"num4Button");
        private static readonly By BTN_5 = By.Uid(@"num5Button");
        private static readonly By BTN_6 = By.Uid(@"num6Button");
        private static readonly By BTN_7 = By.Uid(@"num7Button");
        private static readonly By BTN_8 = By.Uid(@"num8Button");
        private static readonly By BTN_9 = By.Uid(@"num9Button");
        private static readonly By BTN_0 = By.Uid(@"num0Button");

        private static readonly By BTN_CLEAR = By.Uid(@"clearButton");
        private static readonly By BTN_CLEAR_ENTRY = By.Uid(@"clearEntryButton");
        private static readonly By BTN_EQUALS = By.Uid(@"equalButton");
        private static readonly By BTN_PLUS = By.Uid(@"plusButton");
        private static readonly By BTN_MINUS = By.Uid(@"minusButton");
        private static readonly By BTN_MULTIPLY = By.Uid(@"multiplyButton");

        private static readonly By BTN_DIVIDE = By.Uid(@"divideButton");

        private static readonly By BTN_NEGATE = By.Uid(@"negateButton");
        private static readonly By BTN_PERCENT = By.Uid(@"percentButton");


        public static void GoTo()
        {
            CalcDriver.Instance.FindElement(HAMBURGER_MENU_ICON).Click();
            CalcDriver.Instance.FindElement(STANDARD_MENU_OPTION).Click();
        }

        public static void ClickButton3()
        {
            CalcDriver.Instance.FindElement(BTN_3).Click();
        }

        public static void ClickButton5()
        {
            CalcDriver.Instance.FindElement(BTN_5).Click();
        }

        public static void ClickButtonPlus()
        {
            CalcDriver.Instance.FindElement(BTN_PLUS).Click();
        }

        public static void ClickButtonEquals()
        {
            CalcDriver.Instance.FindElement(BTN_EQUALS).Click();
        }

        public static void ClearHistory()
        {
            CalcDriver.Instance.FindElement(BTN_CLEAR_HISTORY).Click();
        }

        public static bool VerifyIsAt()
        {
            var result = CalcDriver.Instance.FindElement(HEADER).Text().Equals(@"Standard");
            return result;
        }

        public static bool VerifyEmptyHistory()
        {
            var actualText = CalcDriver.Instance.FindElement(HISTORY_EMPTY).Text();
            var expectedText = @"no history yet";
            var result = actualText.Contains(expectedText);
            return result;
        }

        public static bool VerifyResultIs(int expectedValue)
        {
            List<CruciatusElement> tortueList = CalcDriver.Instance.FindElements(RESULT_TEXT_BLOCK).ToList();
            int actualValue = Int32.Parse(tortueList[0].Text());
            return actualValue.Equals(expectedValue);
        }

    }
}
