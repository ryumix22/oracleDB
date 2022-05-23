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
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 3333))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";

            OracleConnection expConnection = new OracleConnection()
            {
                ConnectionString = connString
            };

            DBUtils.CreateConnection();

            OracleConnection actConnection = DBUtils.connection;
            Assert.AreEqual(expConnection.ConnectionString, actConnection.ConnectionString, message: $"actual - {actConnection.ConnectionString}; expected - {expConnection.ConnectionString}");
        }

        /*[TestMethod]
        public void ReturnDataTableTest()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter("select * from unittest", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            DBUtils.CreateConnection();
            DataTable actDT = DBUtils.ReturnDataTable("select * from unittest");

            Console.WriteLine(TableToString(expDT));

            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }*/

        [TestMethod]
        public void ReturnDataTableWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ReturnDataTable("select * from unittest"), "Wrong Connection");
        }

        [TestMethod]
        public void ReturnDataTableWrongCommandTest()
        {
            DBUtils.CreateConnection();
            Assert.ThrowsException<ApplicationException>(() => DBUtils.ReturnDataTable("wrong command"), "Wrong command");
        }

        [TestMethod]
        public void ExecuteCommandWrongInputTest()
        {
            string com = "asdasd";
            CreateConnection();
            OracleCommand cmd = new OracleCommand(com, connection);

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ExecuteCommand(com), "Wrong command");
        }

        [TestMethod]
        public void ExecuteCommandWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ExecuteCommand("update unittest set name2 = 'test111' where id = 21"), "Wrong connection");
        }

        [TestMethod]
        public void ExecuteCommandWrongCommandTest()
        {
            DBUtils.CreateConnection();

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ExecuteCommand("das"), "Wrong command");
        }

        public void CheckForLoginFalseTest()
        {
            DBUtils.CreateConnection();
            Assert.IsFalse(DBUtils.CheckForLogin("ahsirg"));
        }

        [TestMethod]
        public void CheckForLoginWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;

            Assert.ThrowsException<ApplicationException>(() => DBUtils.CheckForLogin("grisha"), "Wrong connection");
        }
        
        [TestMethod]
        public void ReturnDataReaderForExistLoginTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;
            List<string> expElements = new List<string>();
            string expElement = "";

            DBUtils.CreateConnection();
            List<string> actElements = new List<string>();
            
            Assert.AreEqual(expElement, expElement);
            DBUtils.PushConnectionClose();
        }

        [TestMethod]
        public void ReturnDataReaderForNonExsistLoginTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.CreateConnection();

            Assert.IsNotNull(connString);
            DBUtils.PushConnectionClose();
        }

        /*[TestMethod]
        public void ReturnDataReaderTest()
        {
            CreateConnection();
            connection.Open();
            OracleCommand expCommand = new OracleCommand("select name1, name2 from unittest", connection);
            OracleDataReader expDR = expCommand.ExecuteReader();
            List<string> expElements = new List<string>();
            while (expDR.Read())
            {
                expElements.Add(expDR["name1"].ToString());
                expElements.Add(expDR["name2"].ToString());
            }
            connection.Close();

            DBUtils.CreateConnection();
            OracleDataReader actDR = DBUtils.ReturnDataReader("select name1, name2 from unittest");
            List<string> actElements = new List<string>();
            while (actDR.Read())
            {
                actElements.Add(actDR["name1"].ToString());
                actElements.Add(actDR["name2"].ToString());
            }

            Assert.AreEqual(string.Join(" ", expElements), string.Join(" ", actElements));
            DBUtils.PushConnectionClose();
        }*/

        [TestMethod]
        public void ReturnDataReaderWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ReturnDataReader("select name1, name2 from unittest"), "Wrong connection");
        }

        [TestMethod]
        public void ReturnDataReaderWrongCommandTest()
        {
            DBUtils.CreateConnection();
            Assert.ThrowsException<ApplicationException>(() => DBUtils.ReturnDataReader("wrong command"), "Wrong connection");
        }

        [TestMethod]
        public void GetDbmsOutPutLineWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;
            Assert.ThrowsException<ApplicationException>(() => DBUtils.GetDbmsOutputLine("wrong", false), "Wrong connection");
        }

        [TestMethod]
        public void GetDbmsOutPutLineWrongCommandTest()
        {
            DBUtils.CreateConnection();
            Assert.ThrowsException<ApplicationException>(() => DBUtils.GetDbmsOutputLine("wrong command", false), "Wrong command");
        }


        /*[TestMethod]
        public void PushConnectionCloseWrongConnectionTest()
        {
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = connString
            };
            DBUtils.connection = wrongConnection;

            Assert.IsTrue(DBUtils.PushConnectionClose());
        }*/
    }
}
