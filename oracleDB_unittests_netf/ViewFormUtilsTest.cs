using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using oracleDB;

namespace oracleDB_unittests_netf
{
    /// <summary>
    /// Сводное описание для ViewFormUtilsTest
    /// </summary>
    [TestClass]
    public class ViewFormUtilsTest
    {
        [TestMethod]
        public void ViewFormWrongOracleTest()
        {
            Assert.IsNull(ViewFormUtils.GetDataTableView("update goods set {0} where id = {1}"));
        }
    }
}
