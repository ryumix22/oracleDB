using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace oracleDB
{
    public partial class MainForm : Form
    {
        static private string[] pagesName = { "goods", "sales", "warehouse1", "warehouse2" };
        static private string[] tableFields = { "(name, priority)", "(good_id, good_count, create_date)", "(good_id, good_count)", "(good_id, good_count)" };

        private int CurrentTabPage { get; set; }

        private void mainTabControl_SelectedIndexChanged(Object sender, TabControlCancelEventArgs e)
        {
            CurrentTabPage = mainTabControl.SelectedIndex;
            MainFormUpdate(pagesName[CurrentTabPage]);
        }

        public MainForm()
        {
            InitializeComponent();
            mainTabControl.Selecting += new TabControlCancelEventHandler(mainTabControl_SelectedIndexChanged);
            MainFormUpdate(pagesName[CurrentTabPage]);
            viewComboBoxUpdate();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            switch (CurrentTabPage)
            {
                case 0:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("insert into {0} {1} values ('{2}', {3})", pagesName[CurrentTabPage], tableFields[CurrentTabPage], nameTextBox.Text, priorityTextBox.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            nameTextBox.Clear();
                            priorityTextBox.Clear();
                            idTextBox.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            nameTextBox.Clear();
                            priorityTextBox.Clear();
                            idTextBox.Clear();
                            MessageBox.Show("Some Exception");
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("insert into {0} {1} values ('{2}', {3}, to_date('{4}', 'DD-MM-YYYY'))",
                                pagesName[CurrentTabPage], tableFields[CurrentTabPage], salesGoodId.Text, salesGoodCount.Text, salesCreateDate.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            salesGoodId.Clear();
                            salesGoodCount.Clear();
                            salesCreateDate.Clear();
                            salesId.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            salesGoodId.Clear();
                            salesGoodCount.Clear();
                            salesCreateDate.Clear();
                            salesId.Clear();
                            Int32.TryParse(salesGoodCount.Text, out int a);
                            if (a < 1) MessageBox.Show("Cant add count < 1");
                            else MessageBox.Show("No such goods in warehouses");
                        }
                    }
                    break;
                case 2:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("insert into {0} {1} values ('{2}', {3})",
                                pagesName[CurrentTabPage], tableFields[CurrentTabPage], ware1GoodId.Text, ware1GoodCount.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            ware1GoodId.Clear();
                            ware1Id.Clear();
                            ware1GoodCount.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            ware1GoodId.Clear();
                            ware1Id.Clear();
                            ware1GoodCount.Clear();
                            MessageBox.Show("Some Exception");
                        }
                    }
                    break;
                case 3:
                    {   
                        try
                        {
                            DBUtils.ExecuteCommand("insert into {0} {1} values ('{2}', {3})",
                                pagesName[CurrentTabPage], tableFields[CurrentTabPage], ware2GoodId.Text, ware2GoodCount.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            ware2GoodId.Clear();
                            ware2Id.Clear();
                            ware2GoodCount.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            ware2GoodId.Clear();
                            ware2Id.Clear();
                            ware2GoodCount.Clear();
                            MessageBox.Show("Cant reduce goods count in warehouse 2 while goods in warehouse 1 exist");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            switch (CurrentTabPage)
            {
                case 0:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("update goods set {0} where id = {1}", configSetString(nameTextBox.Text, priorityTextBox.Text), idTextBox.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            nameTextBox.Clear();
                            priorityTextBox.Clear();
                            idTextBox.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            nameTextBox.Clear();
                            priorityTextBox.Clear();
                            idTextBox.Clear();
                            MessageBox.Show("Some Exception");
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("update sales set {0} where id = {1}",
                                configSetString(salesGoodId.Text, salesGoodCount.Text, salesCreateDate.Text), salesId.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            salesGoodId.Clear();
                            salesGoodCount.Clear();
                            salesCreateDate.Clear();
                            salesId.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            salesGoodId.Clear();
                            salesGoodCount.Clear();
                            salesCreateDate.Clear();
                            salesId.Clear();
                            Int32.TryParse(salesGoodCount.Text, out int a);
                            if (a < 1) MessageBox.Show("Cant add count < 1");
                            else MessageBox.Show("No such goods in warehouses");
                        }
                    }
                    break;
                case 2:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("update warehouse1 set {0} where id = {1}",
                                configSetString(ware1GoodId.Text, ware1GoodCount.Text), ware1Id.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            ware1GoodId.Clear();
                            ware1GoodCount.Clear();
                            ware1Id.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            ware1GoodId.Clear();
                            ware1GoodCount.Clear();
                            ware1Id.Clear();
                            MessageBox.Show("Some Exception");
                        }
                    }
                    break;
                case 3:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("update warehouse2 set {0} where id = {1}",
                                configSetString(ware2GoodId.Text, ware2GoodCount.Text), ware2Id.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            ware2GoodId.Clear();
                            ware2Id.Clear();
                            ware2GoodCount.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            ware2GoodId.Clear();
                            ware2Id.Clear();
                            ware2GoodCount.Clear();
                            MessageBox.Show("Cant reduce goods count in warehouse 2 while goods in warehouse 1 exist");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            switch (CurrentTabPage)
            {
                case 0:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("delete from goods where id = {0}", idTextBox.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            nameTextBox.Clear();
                            priorityTextBox.Clear();
                            idTextBox.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            nameTextBox.Clear();
                            priorityTextBox.Clear();
                            idTextBox.Clear();
                            MessageBox.Show("Some Exception");
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("delete from sales where id = {0}", salesId.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            salesGoodId.Clear();
                            salesGoodCount.Clear();
                            salesCreateDate.Clear();
                            salesId.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            salesGoodId.Clear();
                            salesGoodCount.Clear();
                            salesCreateDate.Clear();
                            salesId.Clear();
                            Int32.TryParse(salesGoodCount.Text, out int a);
                            if (a < 1) MessageBox.Show("Cant add count < 1");
                            else MessageBox.Show("No such goods in warehouses");
                        }
                    }
                    break;
                case 2:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("delete from warehouse1 where id = {0}", ware1Id.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            ware1GoodId.Clear();
                            ware1Id.Clear();
                            ware1GoodCount.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            ware1GoodId.Clear();
                            ware1Id.Clear();
                            ware1GoodCount.Clear();
                            MessageBox.Show("Some Exception");
                        }
                    }
                    break;
                case 3:
                    {
                        try
                        {
                            DBUtils.ExecuteCommand("delete from warehouse2 where id = {0}", ware2Id.Text);
                            MainFormUpdate(pagesName[CurrentTabPage]);
                            ware2GoodId.Clear();
                            ware2Id.Clear();
                            ware2GoodCount.Clear();
                        }
                        catch (OracleException)
                        {
                            DBUtils.PushConnectionClose();
                            ware2GoodId.Clear();
                            ware2Id.Clear();
                            ware2GoodCount.Clear();
                            MessageBox.Show("Cant reduce goods count in warehouse 2 while goods in warehouse 1 exist");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void MainFormUpdate(string currentPage)
        {
            switch (CurrentTabPage)
            {
                case 0:
                    {
                        OracleDataAdapter adapter = DBUtils.SelectAdapter(String.Format("select * from goods"));
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        goodsGridView.DataSource = dt;
                    }
                    break;
                case 1:
                    {
                        OracleDataAdapter adapter = DBUtils.SelectAdapter(String.Format(
                            "select " + "\"goods\"" + ".name, good_id, good_count, create_date, sales.id from sales left join goods " + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id"));
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        salesGridView.DataSource = dt;
                    }
                    break;
                case 2:
                    {
                        OracleDataAdapter adapter = DBUtils.SelectAdapter(String.Format(
                            "select " + "\"goods\"" + ".name, good_id, good_count, warehouse1.id from warehouse1 left join goods " + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id"));
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        warehouse1GridView.DataSource = dt;
                    }
                    break;
                case 3:
                    {
                        OracleDataAdapter adapter = DBUtils.SelectAdapter(String.Format(
                            "select " + "\"goods\"" + ".name, good_id, good_count, warehouse2.id from warehouse2 left join goods " + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id"));
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        warehouse2GridView.DataSource = dt;
                    }
                    break;
                default:
                    break;
            }
        }

        private void viewComboBoxUpdate()
        {
            DBUtils.ExecuteReaderToComboBox("select view_name from user_views", viewComboBox);
            viewComboBox.SelectedIndex = 0;
        }

        private string configSetString(params string[] args)
        {
            string[] goods = { "name = ", "priority = " };
            string[] sales = { "good_id = ", "good_count = ", "create_date = " };
            string[] warehouse1 = { "good_id = ", "good_count = " };
            string[] warehouse2 = { "good_id = ", "good_count = " };
            string[][] fields = { goods, sales, warehouse1, warehouse2 };
            string resultString = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] != "")
                {
                    if (fields[CurrentTabPage][i] == "name = ") resultString += fields[CurrentTabPage][i] + "'" + args[i] + "'";
                    else if (fields[CurrentTabPage][i] == "create_date = ") resultString += fields[CurrentTabPage][i] + "to_date('" + args[i] + "','DD-MM-YYYY')";
                    else resultString += fields[CurrentTabPage][i] + args[i];
                    resultString += ", ";
                }
            }
            resultString = resultString.Remove(resultString.Length - 2);
            return resultString;
        }

        private void watchViewButton_Click(object sender, EventArgs e)
        {
            Form viewForm = new ViewForm((string)viewComboBox.Items[viewComboBox.SelectedIndex]);
            viewForm.Show();
        }

        private void transportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DBUtils.GetDbmsOutputLine("need_to_transport"));
        }

        private void demandButton_Click(object sender, EventArgs e)
        {
            if (id1TextBox.Text != "" && id2TextBox.Text != "")
                MessageBox.Show(DBUtils.GetDbmsOutputLine("compare_demand(" + id1TextBox.Text + ", " + id2TextBox.Text + ")"));
            else MessageBox.Show("Input Goods IDs");
            id1TextBox.Clear();
            id2TextBox.Clear();
        }

        private void grownButton_Click(object sender, EventArgs e)
        {
            if (dateFromTextBox.Text != "" && dateFromTextBox.Text != "")
                MessageBox.Show(DBUtils.GetDbmsOutputLine(
                    "declare " +
                    "a number; " +
                    "begin " +
                    "max_grown(to_date('" + dateFromTextBox.Text + "','DD-MM-YYYY'), to_date('" + dateToTextBox.Text + "','DD-MM-YYYY'), a); " +
                    "dbms_output.put_line('max grown = ' || a);" +
                    "end;", true));
            else MessageBox.Show("Input Dates");
            dateFromTextBox.Clear();
            dateToTextBox.Clear();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Form viewForm = new ViewForm("users_table");
        //    viewForm.Show();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form viewForm = new ViewForm("users_table");
            viewForm.Show();
        }
    }
}
