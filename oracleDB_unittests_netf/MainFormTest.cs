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
    class InternalMainForm : MainForm
    {

        public DataTable GetGoods()
        {
            return (DataTable)this.GetGoodsGridView().DataSource;
        }
        public DataTable GetSales()
        {
            return (DataTable)this.GetSalesGridView().DataSource;
        }
        public DataTable GetWarehouse1()
        {
            return (DataTable)this.GetWarehouse1GridView().DataSource;
        }
        public DataTable GetWarehouse2()
        {
            return (DataTable)this.GetWarehouse2GridView().DataSource;
        }
        public String GetSetString(params string[] args)
        {
            return this.GetConfigSetString(args);
        }
        public ComboBox GetViewComboBoxTest()
        {
            return this.GetViewComboBox();
        }
    }
    [TestClass]
    public class MainFormTest
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
        public void MainFormUpdateGoodsTest()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter("select * from goods", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            string pageName = "goods";
            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 0;
            form.MainFormUpdate(pageName);
            DataTable actDT = form.GetGoods();

            Console.WriteLine(TableToString(actDT));
            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }
        [TestMethod]
        public void MainFormUpdateSalesTest()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter(
                "select " + "\"goods\"" + ".name, good_id, good_count, create_date, sales.id from sales left join goods " + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            string pageName = "sales";
            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 1;
            form.MainFormUpdate(pageName);
            DataTable actDT = form.GetSales();

            Console.WriteLine(TableToString(actDT));
            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }

        [TestMethod]
        public void MainFormUpdateWarehouse1Test()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter(
                "select " + "\"goods\"" + ".name, good_id, good_count, warehouse1.id from warehouse1 left join goods " + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            string pageName = "warehouse1";
            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 2;
            form.MainFormUpdate(pageName);
            DataTable actDT = form.GetWarehouse1();

            Console.WriteLine(TableToString(actDT));
            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }

        [TestMethod]
        public void MainFormUpdateWarehouse2Test()
        {
            CreateConnection();
            connection.Open();
            OracleDataAdapter expAdapter = new OracleDataAdapter(
                "select " + "\"goods\"" + ".name, good_id, good_count, warehouse2.id from warehouse2 left join goods " + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id", connection);
            DataTable expDT = new DataTable();
            expAdapter.Fill(expDT);
            connection.Close();

            string pageName = "warehouse2";
            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 3;
            form.MainFormUpdate(pageName);
            DataTable actDT = form.GetWarehouse2();

            Console.WriteLine(TableToString(actDT));
            Assert.AreEqual(TableToString(expDT), TableToString(actDT));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Wrong Page Name")]
        public void MainFormUpdateWrongPageTest()
        {
            string pageName = "sales";
            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();
            form.CurrentTabPage = 5;
            form.MainFormUpdate(pageName);
        }

        [TestMethod]
        public void viewComboBoxUpdateTest()
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
            InternalMainForm form = new InternalMainForm();

            string[] actElements = form.GetViewComboBoxTest().Items.Cast <string>().ToArray();

            Assert.AreEqual(string.Join(" ", expElements), string.Join(" ", actElements));
           }

        [TestMethod]
        public void viewComboBoxUpdateConnectionTest()
        {
            string WrongConnection = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 222.0.0.2)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));Password=mypass;User ID=c##test2";
            OracleConnection wrongConnection = new OracleConnection()
            {
                ConnectionString = WrongConnection
            };
            DBUtils.con = wrongConnection;
            CreateConnection();
            connection.Open();
            OracleCommand expCommand = new OracleCommand("select view_name from user_views", wrongConnection);
            ComboBox TestComboBox = new ComboBox();
           

            Assert.ThrowsException<ApplicationException>(() => DBUtils.ExecuteReaderToComboBox("select view_name from user_views", TestComboBox), "No connection with DataBase");
        }


        [TestMethod]
        public void ConfigSetStringGoodsTest()
        {
            string expResultString = "name = 'car', priority = 2";
            string[] TextBoxTest = { "car", "2" };

            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 0;
            string actResultString = form.GetSetString(TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringSalesTest1()
        {
            string expResultString = "good_id = 3, good_count = 40, create_date = to_date('10.10.2021','DD-MM-YYYY')";
            string[] TextBoxTest = { "3", "40", "10.10.2021"};

            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 1;
            string actResultString = form.GetSetString(TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringSalesTest2()
        {
            string expResultString = "good_id = 3, good_count = 40, create_date = to_date('10.10.2021','DD-MM-YYYY')";
            string[] TextBoxTest = { "3", "40", "10-10-2021" };

            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 1;
            string actResultString = form.GetSetString(TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreNotEqual(expResultString, actResultString);
        }
        [TestMethod]
        public void ConfigSetStringWarehouse1Test()
        {
            string expResultString = "good_id = 6, good_count = 20";
            string[] TextBoxTest = { "6", "20" };

            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 2;
            string actResultString = form.GetSetString(TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }

        [TestMethod]
        public void ConfigSetStringWarehouse2Test()
        {
            string expResultString = "good_id = 3, good_count = 400";
            string[] TextBoxTest = { "3", "400" };

            DBUtils.CreateConnection();
            InternalMainForm form = new InternalMainForm();

            form.CurrentTabPage = 3;
            string actResultString = form.GetSetString(TextBoxTest);

            Console.WriteLine(actResultString);
            Assert.AreEqual(expResultString, actResultString);
        }



    }

}
