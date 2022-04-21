using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace oracleDB_othertests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // KeyboardInput VirtualKeys=""grisha222"Keys.Tab + Keys.Tab"12345"Keys.Tab + Keys.TabKeys.Return + Keys.Return" CapsLock=False NumLock=False ScrollLock=False
            Console.WriteLine("KeyboardInput VirtualKeys=\"\"grisha222\"Keys.Tab + Keys.Tab\"12345\"Keys.Tab + Keys.TabKeys.Return + Keys.Return\" CapsLock=False NumLock=False ScrollLock=False");
            System.Threading.Thread.Sleep(100);
            winElem_.SendKeys("grisha222");
            winElem_.SendKeys(Keys.Tab + Keys.Tab);
            winElem_.SendKeys("12345");
            winElem_.SendKeys(Keys.Tab + Keys.Tab);
            winElem_.SendKeys(Keys.Return + Keys.Return);


            // LeftClick on Button "ОК" at (42,7)
            Console.WriteLine("LeftClick on Button \"ОК\" at (42,7)");
            string xpath_LeftClickButtonОК_42_7 = "/Pane[@ClassName=\"#32769\"][@Name=\"Рабочий стол 1\"]/Window[@Name=\"Form1\"][@AutomationId=\"LoginForm\"]/Window[@ClassName=\"#32770\"]/Button[@ClassName=\"Button\"][@Name=\"ОК\"]";
            var winElem_LeftClickButtonОК_42_7 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickButtonОК_42_7);
            if (winElem_LeftClickButtonОК_42_7 != null)
            {
                winElem_LeftClickButtonОК_42_7.Click();
            }
            else
            {
                Console.WriteLine($"Failed to find element using xpath: {xpath_LeftClickButtonОК_42_7}");
                return;
            }



        }
    }
}
