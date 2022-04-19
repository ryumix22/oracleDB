using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using oracleDB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace oracleDB_unittests_netf
{
    [TestClass]
    public class DBUtilsTest
    {
        [TestMethod]
        public void CreateConnectionStringTest()
        {
            string host = "127.0.0.1";
            int port = 1521;
            string sid = "xe";
            string userName = "c##test2";
            string pass = "mypass";

            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";

            OracleConnection expConnection = new OracleConnection()
            {
                ConnectionString = connString
            };

            DBUtils.CreateConnection();

            OracleConnection actConnection = DBUtils.con;
            Assert.AreEqual(expConnection.ConnectionString, actConnection.ConnectionString, message: $"actual - {actConnection.ConnectionString}; expected - {expConnection.ConnectionString}");
        }

        [TestMethod]
        public void SelectAdapterWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.con = wrongConnection;
            //OracleDataAdapter adapter = DBUtils.SelectAdapter("select * from unittest");

            Assert.ThrowsException<ApplicationException>(() => DBUtils.SelectAdapter("select * from unittest"), "Wrong Connection");
        }
    }
}
