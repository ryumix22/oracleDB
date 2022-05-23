using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using oracleDB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oracleDB_unittests_netf
{
    [TestClass]
    public class MainFormUtilsTest
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
        public void GetDataTableInvalidTest()
        {
            DBUtils.CreateConnection();
            DataTable actDT = utils.GetDataTable("wrong command");

            Assert.IsNull(actDT);
        }

        [TestMethod]
        public void GetDataTableWrongConnectionTest()
        {
            string WrongConnection = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = WrongConnection
            };
            DBUtils.connection = wrongConnection;
            Assert.IsNull(utils.GetDataTable("select * from unittest"));
        }

        [TestMethod]
        public void InsertTestWrongCountOfParams()
        {
            MainFormUtils mf = new MainFormUtils();

            int act = mf.Insert("test", 1, "asr");

            Assert.AreEqual(0, act);
        }

        [TestMethod]
        public void InsertTestWrongCommand()
        {
            MainFormUtils mf = new MainFormUtils();

            int act = mf.Insert("insert into {0} {1} values ('{2}', {3})", 0, "dsa", "asd", "asd", "asd");

            Assert.AreEqual(0, act);
        }

        [TestMethod]
        public void UpdateTestWrongCountOfParams()
        {
            MainFormUtils mf = new MainFormUtils();

            int act = mf.Update("test", 1, "asr");

            Assert.AreEqual(0, act);
        }

        [TestMethod]
        public void UpdateTestWrongCommand()
        {
            MainFormUtils mf = new MainFormUtils();

            int act = mf.Update("update goods set {0} where id = {1}", 0, "asd", "aasd", "as");

            Assert.AreEqual(0, act);
        }

        [TestMethod]
        public void DeleteTestWrongOracle()
        {
            MainFormUtils mf = new MainFormUtils();

            int act = mf.Delete("update goods set {0} where id = {1}", "0");

            Assert.AreEqual(0, act);
        }

        [TestMethod]
        public void ViewComboBoxDataReaderWrongConnectionTest()
        {
            string WrongConnection = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = WrongConnection
            };
            DBUtils.connection = wrongConnection;
            Assert.IsNull(utils.ViewComboBoxDataReader());
        }

        [TestMethod]
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
            string[] TextBoxTest = { "3", "40", "10.10.2021"};

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
        }

        /*[TestMethod]
        public void GetIndexOfIdInTable()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter("select * from goods", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);

            DataGridView view = new DataGridView();
            view.DataSource = expDT;
            DataGridViewCell expCell = view.Rows[0].Cells[0];
            DataGridViewCell actCell = utils.GetIndexOfIdInTable("1", view);
            connection.Close();

            
            Assert.AreEqual(expCell.Value, actCell.Value);
        }*/
    }
}
