using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using oracleDB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Collections.Generic;

namespace oracleDB_unittests_netf
{
    [TestClass]
    class LoginFormUtilsTest
    {
        [TestMethod]
        public void LoginUtilsAllRightTest()
        {
            LoginFormUtils utils = new LoginFormUtils("grisha2", "12345");
            Assert.IsTrue(utils.isLoginExist && utils.isPasswordCorrect);
        }

        /*[TestMethod]
        public void LoginUtilsAllRightTest()
        {
            LoginFormUtils utils = new LoginFormUtils("grisha2", "12345");
            Assert.IsTrue(utils.isLoginExist && !utils.isPasswordCorrect);
        }*/
    }
}
