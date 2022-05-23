using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using oracleDB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace oracleDB_unittests_netf
{
    [TestClass]
    public class DBUtilsTest
    {
        private static OracleConnection connection { get; set; }

        private MainFormUtils utils = new MainFormUtils();
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
        public void CheckForLoginTrueTest()
        {
            DBUtils.CreateConnection();
            Assert.IsTrue(DBUtils.CheckForLogin("grisha"));
        }

        public void CheckForLoginFalseTest()
        {
            DBUtils.CreateConnection();
            Assert.IsFalse(DBUtils.CheckForLogin("ahsirg"));
        }

        [TestMethod]
        public void ReturnDataReaderForExistLoginTest()
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
            OracleDataReader actDR = DBUtils.ReturnDataReaderForLogin("grisha");
            List<string> actElements = new List<string>();
            while (actDR.Read())
            {
                actElements.Add(actDR["username"].ToString());
                actElements.Add(actDR["user_password"].ToString());
            }

            Assert.AreEqual(string.Join(" ", expElements), string.Join(" ", actElements));
            DBUtils.PushConnectionClose();
        }

        [TestMethod]
        public void ReturnDataReaderForNonExsistLoginTest()
        {
            DBUtils.CreateConnection();
            OracleDataReader actDR = DBUtils.ReturnDataReaderForLogin("ahsirg");

            Assert.IsFalse(actDR.Read());
            DBUtils.PushConnectionClose();
        }

        [TestMethod]
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
        }

        [TestMethod]
        public void GetDataTableValidTest()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter("select * from unittest", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            DBUtils.CreateConnection();
            DataTable actDT = utils.GetDataTable("select * from unittest");

            Console.WriteLine(TableToString(actDT));
            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }

        [TestMethod]
        public void InsertTest()
        {
            DBUtils.CreateConnection();
            string com = "insert into {0}{1} values('{2}', '{3}', {4})";
            utils.Insert(com, 1, "unittest", "(name1, name2, num1)", "test5", "test15", "500");

            CreateConnection();
            connection.Open();

            OracleCommand actCommand = new OracleCommand("select * from unittest where name1 = 'test5'", connection);

            OracleDataReader actDR = actCommand.ExecuteReader();
            DBUtils.ExecuteCommand("delete from unittest where name1 = 'test5'");
            List<string> actElements = new List<string>();
            while (actDR.Read())
            {
                actElements.Add(actDR["name1"].ToString());
                actElements.Add(actDR["name2"].ToString());
                actElements.Add(actDR["num1"].ToString());
            }
            connection.Close();

            Assert.AreEqual("test5 test15 500", string.Join(" ", actElements));
        }

        [TestMethod]
        public void ViewComboBoxDataReaderValidTest()
        {
            CreateConnection();
            connection.Open();
            OracleCommand expCommand = new OracleCommand("select view_name from user_views", connection);
            OracleDataReader expDR = expCommand.ExecuteReader();
            List<string> expElements = new List<string>();
            while (expDR.Read())
            {
                Console.WriteLine(expDR["view_name"].ToString());
                expElements.Add(expDR["view_name"].ToString());
            }
            connection.Close();

            DBUtils.CreateConnection();
            OracleDataReader actDR = utils.ViewComboBoxDataReader();
            List<string> actElements = new List<string>();
            while (actDR.Read())
            {
                Console.WriteLine(actDR["view_name"].ToString());
                actElements.Add(actDR["view_name"].ToString());
            }

            Assert.AreEqual(string.Join(" ", expElements), string.Join(" ", actElements));
        }

        //МОДУЛЬНЫЕ ТЕСТЫ

        /*[TestMethod]
        public void ConfigSetStringGoodsTest()
        {
            string expResultString = "name = 'car', priority = 2";
            string[] TextBoxTest = { "car", "2" };

            DBUtils.CreateConnection();

            string actResultString = utils.ConfigSetString(0, TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringSalesTest1()
        {
            string expResultString = "good_id = 3, good_count = 40, create_date = to_date('10.10.2021','DD-MM-YYYY')";
            string[] TextBoxTest = { "3", "40", "10.10.2021" };

            DBUtils.CreateConnection();

            string actResultString = utils.ConfigSetString(1, TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringSalesTest2()
        {
            string expResultString = "good_id = 3, good_count = 40, create_date = to_date('10-10-2021','DD-MM-YYYY')";
            string[] TextBoxTest = { "3", "40", "10-10-2021" };

            DBUtils.CreateConnection();

            string actResultString = utils.ConfigSetString(1, TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringWarehouse1Test()
        {
            string expResultString = "good_id = 6, good_count = 20";
            string[] TextBoxTest = { "6", "20" };

            DBUtils.CreateConnection();

            string actResultString = utils.ConfigSetString(2, TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringWarehouse2Test()
        {
            string expResultString = "good_id = 3, good_count = 400";
            string[] TextBoxTest = { "3", "400" };

            DBUtils.CreateConnection();

            string actResultString = utils.ConfigSetString(3, TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }*/

        [TestMethod]
        public void LoginUtilsAllRightTest()
        {
            LoginFormUtils utils = new LoginFormUtils("grisha2", "12345");
            Assert.IsTrue(utils.isLoginExist && utils.isPasswordCorrect);
        }

        [TestMethod]
        public void UpdateTest()
        {
            DBUtils.CreateConnection();
            string com = "insert into {0}{1} values('{2}', '{3}', {4})";
            utils.Insert(com, 1, "unittest", "(name1, name2, num1)", "test33", "test333", "3000");

            CreateConnection();
            connection.Open();
            utils.Update("Update unittest set name2 = 'testupdate' where num1 = 3000", 1, "unittest", "(name1, name2, num1)", "test33", "test333", "3000");
            OracleCommand actCommand = new OracleCommand("select * from unittest where name1 = 'test33'", connection);
            OracleDataReader actDR = actCommand.ExecuteReader();
            DBUtils.ExecuteCommand("delete from unittest where name1 = 'test33'");
            List<string> actElements = new List<string>();
            while (actDR.Read())
            {
                actElements.Add(actDR["name1"].ToString());
                actElements.Add(actDR["name2"].ToString());
                actElements.Add(actDR["num1"].ToString());
            }
            connection.Close();

            Assert.AreEqual("test33 testupdate 3000", string.Join(" ", actElements));
        }

        [TestMethod]
        public void DeleteTest()
        {
            DBUtils.CreateConnection();
            string com = "insert into {0}{1} values('{2}', '{3}', {4})";
            utils.Insert(com, 1, "unittest", "(name1, name2, num1)", "test6", "test16", "600");

            CreateConnection();
            connection.Open();
            OracleCommand actCommand = new OracleCommand("select * from unittest where name1 = 'test6'", connection);
            OracleDataReader actDR = actCommand.ExecuteReader();
            List<string> actElements = new List<string>();
            string id = "";
            while (actDR.Read())
            {
                actElements.Add(actDR["name1"].ToString());
                actElements.Add(actDR["name2"].ToString());
                actElements.Add(actDR["num1"].ToString());
            }

            utils.Delete("delete from unittest where name1 = '{0}'", actElements[0]);
            OracleCommand actCommand2 = new OracleCommand("select * from unittest where name1 = 'test6'", connection);
            OracleDataReader actDR2 = actCommand2.ExecuteReader();
            Assert.IsFalse(actDR2.Read());
            connection.Close();
        }

    }
}


       