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
    public class DBUtilsTest
    {
        private static OracleConnection connection { get; set; }

        private static void CreateConnection()
        {
            string host = "127.0.0.1";
            int port = 1521;
            string sid = "xe";
            string userName = "c##test2";
            string pass = "mypass";

            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + pass + ";User ID=" + userName;

            OracleConnection conn = new OracleConnection
            {
                ConnectionString = connString
            };

            connection = conn;
        }

        private string TableToString(DataTable table)
        {
            string output = "";
            foreach (DataRow row in table.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    output += cell.ToString() + " ";
                }
                output += "\n";
            }
            return output;
        }

        [TestMethod]
        public void CreateConnectionStringTest()
        {
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

        [TestMethod]
        public void SelectAdapterTest()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter("select * from unittest", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            DBUtils.CreateConnection();
            OracleDataAdapter actAdapter = DBUtils.SelectAdapter("select * from unittest");
            DataTable actDT = new DataTable();
            actAdapter.Fill(actDT);

            Console.WriteLine(TableToString(expDT));

            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }

        [TestMethod]
        public void ExecuteCommandTest()
        {
            string com = "update unittest set name2 = 'test111' where id = 21";
            CreateConnection();
            OracleCommand cmd = new OracleCommand(com, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            DBUtils.CreateConnection();
            DBUtils.ExecuteCommand("update unittest set name2 = 'test111' where id = {0}", "21");

            connection.Open();
            OracleDataAdapter actAdapter = new OracleDataAdapter("select name2 from unittest where id = 21", connection);
            DataTable actDT = new DataTable();
            actAdapter.Fill(actDT);
            connection.Close();


            Assert.AreEqual(TableToString(actDT), "test111 \n");
        }

        [TestMethod]
        public void ExecuteCommandWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.con = wrongConnection;

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ExecuteCommand("update unittest set name2 = 'test111' where id = 21"), "Wrong connection");
        }

        [TestMethod]
        public void ExecuteCommandWrongCommandTest()
        {
            DBUtils.CreateConnection();

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ExecuteCommand("das"), "Wrong command");
        }

        [TestMethod]
        public void CheckForLoginTest()
        {
            DBUtils.CreateConnection();
            Assert.IsTrue(DBUtils.CheckForLogin("grisha"));
        }

        [TestMethod]
        public void WrongConnectionCheckForLoginTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.con = wrongConnection;

            Assert.ThrowsException<ApplicationException>(() => DBUtils.CheckForLogin("grisha"), "Wrong connection");
        }
        
        [TestMethod]
        public void ReturnDataReaderForLoginTest()
        {
            CreateConnection();
            connection.Open();
            OracleCommand expCommand = new OracleCommand("select * from users_table where username = 'grisha'", connection);
            OracleDataReader expDR = expCommand.ExecuteReader();
            List<string> expElements = new List<string>();
            while (expDR.Read())
            {
                expElements.Add(expDR["username"].ToString());
                expElements.Add(expDR["user_password"].ToString());
            }
            connection.Close();

            DBUtils.CreateConnection();
            OracleDataReader actDP = DBUtils.ReturnDataReaderForLogin("grisha");
            List<string> actElements = new List<string>();
            while (actDP.Read())
            {
                actElements.Add(actDP["username"].ToString());
                actElements.Add(actDP["user_password"].ToString());
            }

            Assert.AreEqual(string.Join(" ", expElements), string.Join(" ", actElements));
        }
    }
}
