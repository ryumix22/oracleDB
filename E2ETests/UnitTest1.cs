using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace DesktopAppAutomation
{
    public class Tests
    {
        public const string DriverUrl = "http://127.0.0.1:4723/";
        public WindowsDriver<WindowsElement> DesktopSession;
        [SetUp]
        public void Setup()
        {
            AppiumOptions Options = new AppiumOptions();
            Options.AddAdditionalCapability("app", "C:\\Users\\zaqwerd\\Documents\\oracleDB\\oracleDB\\bin\\Debug\\oracleDB.exe");
            Options.AddAdditionalCapability("deviceName", "WindowsPC");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), Options);
            Assert.IsNotNull(DesktopSession);
        }

        [Test]
        public void NoPassE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement ErrorBar = DesktopSession.FindElementByAccessibilityId("65535");
            string ActErrorText = ErrorBar.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("Please, enter login and password", ActErrorText);
        }

        [Test]
        public void NoSuchUserE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("GGGRISHA");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement ErrorBar = DesktopSession.FindElementByAccessibilityId("65535");
            string ActErrorText = ErrorBar.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("No such user", ActErrorText);
        }

        [Test]
        public void UserExistsE2ETest()
        {
            WindowsElement RegisterClick = DesktopSession.FindElementByAccessibilityId("registerButton");
            RegisterClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("loginTextBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("passwordTextBox");
            PassEnter.SendKeys("12345");

            WindowsElement AddUserClick = DesktopSession.FindElementByAccessibilityId("registerButton");
            AddUserClick.Click();

            var currentWindowHandle2 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles22 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles22[0]);

            WindowsElement ErrorBar = DesktopSession.FindElementByAccessibilityId("65535");
            string ActErrorText = ErrorBar.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();

            var currentWindowHandle3 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles23 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles23[0]);

            WindowsElement ClosePage = DesktopSession.FindElementByName("Закрыть");
            ClosePage.Click();

            var currentWindowHandle4 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles24 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles24[0]);

            DesktopSession.CloseApp();

            Assert.AreEqual("Such user is already created", ActErrorText);
        }


        [Test]
        public void WrongPassE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("333");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement ErrorBar = DesktopSession.FindElementByAccessibilityId("65535");
            string ActErrorText = ErrorBar.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("Wrong password", ActErrorText);
        }



        [Test]
        public void LoginInsertE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement TableGoodsEnterName = DesktopSession.FindElementByAccessibilityId("nameTextBox");
            TableGoodsEnterName.SendKeys("ZTestGood1");
            WindowsElement TableGoodsEnterPriority = DesktopSession.FindElementByAccessibilityId("priorityTextBox");
            TableGoodsEnterPriority.SendKeys("666");
            WindowsElement InsertButton = DesktopSession.FindElementByAccessibilityId("insertButton");
            InsertButton.Click();
            WindowsElement SortButton = DesktopSession.FindElementByName("NAME");
            SortButton.Click();
            WindowsElement StringNum10Name = DesktopSession.FindElementByName("NAME Строка 8");
            string ActElemName = StringNum10Name.GetAttribute("Value.Value");
            WindowsElement StringNum10ID = DesktopSession.FindElementByName("ID Строка 8");
            string ActElemID = StringNum10ID.GetAttribute("Value.Value");
            WindowsElement TableGoodsEnterID = DesktopSession.FindElementByAccessibilityId("idTextBox");
            TableGoodsEnterID.SendKeys(ActElemID);
            WindowsElement DeleteButton = DesktopSession.FindElementByAccessibilityId("deleteButton");
            DeleteButton.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("ZTestGood1", ActElemName);
        }

        [Test]
        public void SalesInsertE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);
            WindowsElement SalesButtonClick = DesktopSession.FindElementByName("Sales");
            SalesButtonClick.Click();
            WindowsElement salesGoodIdsEnterID = DesktopSession.FindElementByAccessibilityId("salesGoodId");
            salesGoodIdsEnterID.SendKeys("41");
            WindowsElement salesGoodIdCountEnterID = DesktopSession.FindElementByAccessibilityId("salesGoodCount");
            salesGoodIdCountEnterID.SendKeys("3");
            WindowsElement salesGoodIdCountEnterDate = DesktopSession.FindElementByAccessibilityId("salesCreateDate");
            salesGoodIdCountEnterDate.SendKeys("20.05.2022");
            WindowsElement InsertButton = DesktopSession.FindElementByAccessibilityId("insertButton");
            InsertButton.Click();
            WindowsElement StringNum1Id = DesktopSession.FindElementByName("GOOD_ID Строка 1");
            string ActElemName = StringNum1Id.GetAttribute("Value.Value");
            WindowsElement StringNum1ID = DesktopSession.FindElementByName("ID Строка 1");
            string ActElemID = StringNum1ID.GetAttribute("Value.Value");
            WindowsElement TableSalesEnterID = DesktopSession.FindElementByAccessibilityId("salesId");
            TableSalesEnterID.SendKeys(ActElemID);
            WindowsElement DeleteButton = DesktopSession.FindElementByAccessibilityId("deleteButton");
            DeleteButton.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("41", ActElemName);
        }

        [Test]
        public void SalesWrongInsertE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement SalesButtonClick = DesktopSession.FindElementByName("Sales");
            SalesButtonClick.Click();
            WindowsElement salesGoodIdsEnterID = DesktopSession.FindElementByAccessibilityId("salesGoodId");
            salesGoodIdsEnterID.SendKeys("100000");
            WindowsElement salesGoodIdCountEnterID = DesktopSession.FindElementByAccessibilityId("salesGoodCount");
            salesGoodIdCountEnterID.SendKeys("3");
            WindowsElement salesGoodIdCountEnterDate = DesktopSession.FindElementByAccessibilityId("salesCreateDate");
            salesGoodIdCountEnterDate.SendKeys("20.05.2022");
            WindowsElement InsertButton = DesktopSession.FindElementByAccessibilityId("insertButton");
            InsertButton.Click();

            var currentWindowHandle2 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles22 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles22[0]);

            WindowsElement ErrorWindow = DesktopSession.FindElementByAccessibilityId("65535");
            string ErrorText = ErrorWindow.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("Wrong Command", ErrorText);
        }

        [Test]
        public void SalesWrongFieldsE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement SalesButtonClick = DesktopSession.FindElementByName("Sales");
            SalesButtonClick.Click();
            WindowsElement salesGoodIdsEnterID = DesktopSession.FindElementByAccessibilityId("salesGoodId");
            salesGoodIdsEnterID.SendKeys("41");
            WindowsElement InsertButton = DesktopSession.FindElementByAccessibilityId("insertButton");
            InsertButton.Click();

            var currentWindowHandle2 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles22 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles22[0]);

            WindowsElement ErrorWindow = DesktopSession.FindElementByAccessibilityId("65535");
            string ErrorText = ErrorWindow.GetAttribute("Name");

            WindowsElement AcceptClick = DesktopSession.FindElementByAccessibilityId("2");
            AcceptClick.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("Fill all fields", ErrorText);
        }

        [Test]
        public void SalesUpdateE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement SalesButtonClick = DesktopSession.FindElementByName("Sales");
            SalesButtonClick.Click();
            WindowsElement TableSales2EnterID = DesktopSession.FindElementByAccessibilityId("salesId");
            TableSales2EnterID.SendKeys("23");
            WindowsElement salesGoodIdCountEnterID = DesktopSession.FindElementByAccessibilityId("salesGoodCount");
            salesGoodIdCountEnterID.SendKeys("5");
            WindowsElement InsertButton = DesktopSession.FindElementByAccessibilityId("updateButton");
            InsertButton.Click();
            WindowsElement StringNum1Id = DesktopSession.FindElementByName("GOOD_COUNT Строка 0");
            string ActElemCount = StringNum1Id.GetAttribute("Value.Value");
            TableSales2EnterID.SendKeys("23");
            salesGoodIdCountEnterID.SendKeys("3");
            InsertButton.Click();

            DesktopSession.CloseApp();

            Assert.AreEqual("5", ActElemCount);
        }


        [Test]
        public void WatchViewE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement ViewButton = DesktopSession.FindElementByAccessibilityId("watchViewButton");
            ViewButton.Click();

            var currentWindowHandle2 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles22 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles22[0]);

            WindowsElement NewBarName = DesktopSession.FindElementByAccessibilityId("ViewForm");
            string ActNewBar = NewBarName.GetAttribute("Name");

            WindowsElement ClosePage = DesktopSession.FindElementByName("Закрыть");
            ClosePage.Click();

            var currentWindowHandle3 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles23 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles23[0]);

            DesktopSession.CloseApp();

            Assert.AreEqual("WAREHOUSE1__COUNT_LESS_THEN_N", ActNewBar);
        }

        [Test]
        public void UsersE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement UsersButton = DesktopSession.FindElementByName("Users");
            UsersButton.Click();

            var currentWindowHandle2 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles22 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles22[0]);

            WindowsElement NewBarName = DesktopSession.FindElementByAccessibilityId("ViewForm");
            string ActNewBar = NewBarName.GetAttribute("Name");

            WindowsElement ClosePage = DesktopSession.FindElementByName("Закрыть");
            ClosePage.Click();

            var currentWindowHandle3 = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles23 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles23[0]);

            DesktopSession.CloseApp();

            Assert.AreEqual("users_table", ActNewBar);
        }

        [Test]
        public void FindInsertE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);

            WindowsElement FindBoxEnter = DesktopSession.FindElementByAccessibilityId("idFindTextBox");
            FindBoxEnter.SendKeys("1");
            WindowsElement FindButtonClick = DesktopSession.FindElementByAccessibilityId("idFindButton");
            FindButtonClick.Click();
            WindowsElement StringFound = DesktopSession.FindElementByName("NAME Строка 6");
            string ActFoundName = StringFound.GetAttribute("HasKeyboardFocus");
            bool ActFound = bool.Parse(ActFoundName);


            DesktopSession.CloseApp();

            Assert.IsTrue(ActFound);
        }

        [Test]
        public void WarehouseInsertE2ETest()
        {
            WindowsElement LoginEnter = DesktopSession.FindElementByAccessibilityId("LoginBox");
            LoginEnter.SendKeys("grisha2");
            WindowsElement PassEnter = DesktopSession.FindElementByAccessibilityId("PassBox");
            PassEnter.SendKeys("12345");
            WindowsElement ConnectClick = DesktopSession.FindElementByAccessibilityId("button1");
            ConnectClick.Click();

            var currentWindowHandle = DesktopSession.CurrentWindowHandle;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles2 = DesktopSession.WindowHandles;
            DesktopSession.SwitchTo().Window(allWindowHandles2[0]);
            WindowsElement SalesButtonClick = DesktopSession.FindElementByName("WareHouse1");
            SalesButtonClick.Click();
            WindowsElement salesGoodIdsEnterID = DesktopSession.FindElementByAccessibilityId("ware1GoodId");
            salesGoodIdsEnterID.SendKeys("21");
            WindowsElement salesGoodIdCountEnterID = DesktopSession.FindElementByAccessibilityId("ware1GoodCount");
            salesGoodIdCountEnterID.SendKeys("20");
            WindowsElement InsertButton = DesktopSession.FindElementByAccessibilityId("insertButton");
            InsertButton.Click();
            WindowsElement SortButton = DesktopSession.FindElementByName("NAME");
            SortButton.Click();
            WindowsElement StringNum1Id = DesktopSession.FindElementByName("NAME Строка 2");
            string ActElemName = StringNum1Id.GetAttribute("Value.Value");
            WindowsElement StringNum2ID = DesktopSession.FindElementByName("ID Строка 2");
            string ActElemID = StringNum2ID.GetAttribute("Value.Value");
            WindowsElement TableSalesEnterID = DesktopSession.FindElementByAccessibilityId("ware1Id");
            TableSalesEnterID.SendKeys(ActElemID);
            WindowsElement DeleteButton = DesktopSession.FindElementByAccessibilityId("deleteButton");
            DeleteButton.Click();
            DesktopSession.CloseApp();

            Assert.AreEqual("tetriz", ActElemName);
        }








        /*        [TearDown]
                public void Close()
                {
                    DesktopSession.CloseApp();
                }*/
    }
}