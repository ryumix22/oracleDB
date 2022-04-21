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
        private static string[] pagesName = { "goods", "sales", "warehouse1", "warehouse2" };
        private static string[] tableFields = { "(name, priority)", "(good_id, good_count, create_date)", "(good_id, good_count)", "(good_id, good_count)" };

        public int CurrentTabPage = 0;
        private MainFormUtils utils;

        protected internal DataGridView GetGoodsGridView()
        {
            return goodsGridView;
        }
        protected internal DataGridView GetSalesGridView()
        {
            return salesGridView;
        }
        protected internal DataGridView GetWarehouse1GridView()
        {
            return warehouse1GridView;
        }
        protected internal DataGridView GetWarehouse2GridView()
        {
            return warehouse2GridView;
        }
        protected internal ComboBox GetViewComboBox()
        {
            return viewComboBox;
        }

        public MainForm()
        {
            InitializeComponent();
            utils = new MainFormUtils();
            mainTabControl.Selecting += new TabControlCancelEventHandler(mainTabControl_SelectedIndexChanged);
            MainFormUpdate();
            ViewComboBoxUpdate();
        }

        public void MainFormUpdate()
        {
            DataTable dt;
            switch(CurrentTabPage)
            {
                case 0:
                    {
                        dt = utils.GetDataTable("select * from goods");
                        goodsGridView.DataSource = dt;
                        if (dt == null)
                        {
                            MessageBox.Show("No Data avaliable for goods");
                        }
                    }
                    break;
                case 1:
                    {
                        dt = utils.GetDataTable("select " + "\"goods\"" + ".name, good_id, good_count, create_date, sales.id from sales left join goods " +
                            "\"goods\"" + " on " + "\"goods\"" + ".id = good_id");
                        salesGridView.DataSource = dt;
                        if (dt == null)
                        {
                            MessageBox.Show("No Data avaliable for sales");
                        }
                    }
                    break;
                case 2:
                    {
                        dt = utils.GetDataTable("select " + "\"goods\"" + ".name, good_id, good_count, warehouse1.id from warehouse1 left join goods "
                            + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id");
                        warehouse1GridView.DataSource = dt;
                        if (dt == null)
                        {
                            MessageBox.Show("No Data avaliable for warehouse1");
                        }
                    }
                    break;
                case 3:
                    {
                        dt = utils.GetDataTable("select " + "\"goods\"" + ".name, good_id, good_count, warehouse2.id from warehouse2 left join goods "
                            + "\"goods\"" + " on " + "\"goods\"" + ".id = good_id");
                        warehouse2GridView.DataSource = dt;
                        if (dt == null)
                        {
                            MessageBox.Show("No Data avaliable for warehouse2");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void ViewComboBoxUpdate()
        {
            using (OracleDataReader dr = utils.ViewComboBoxDataReader())
            {
                if (dr == null)
                {
                    MessageBox.Show("Unable to fill Views ComboBox");
                    return;
                }
                while (dr.Read())
                {
                    string viewName = dr["view_name"].ToString();
                    viewComboBox.Items.Add(viewName);
                }
            }
            DBUtils.PushConnectionClose();
            viewComboBox.SelectedIndex = 0;
        }

        private void mainTabControl_SelectedIndexChanged(Object sender, TabControlCancelEventArgs e)
        {
            CurrentTabPage = mainTabControl.SelectedIndex;
            MainFormUpdate();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            switch (CurrentTabPage)
            {
                case 0:
                    {
                        if (nameTextBox.Text == "" || priorityTextBox.Text == "")
                        {
                            MessageBox.Show("Fill all fields");
                            return;
                        }
                        utils.Insert("insert into {0} {1} values ('{2}', {3})", 0, pagesName[CurrentTabPage], tableFields[CurrentTabPage], nameTextBox.Text, priorityTextBox.Text);
                        MainFormUpdate();
                        nameTextBox.Clear();
                        priorityTextBox.Clear();
                        idTextBox.Clear();
                    }
                    break;
                case 1:
                    {
                        if (salesGoodId.Text == "" || salesGoodCount.Text == "" || salesCreateDate.Text == "")
                        {
                            MessageBox.Show("Fill all fields");
                            return;
                        }
                        int size;
                        Int32.TryParse(salesGoodCount.Text, out size);
                        if (size < 1)
                        {
                            MessageBox.Show("Size must be more then 1");
                            return;
                        }
                        utils.Insert("insert into {0} {1} values ('{2}', {3}, to_date('{4}', 'DD-MM-YYYY'))", 1, pagesName[CurrentTabPage], tableFields[CurrentTabPage], salesGoodId.Text, salesGoodCount.Text, salesCreateDate.Text);
                        MainFormUpdate();
                        salesGoodId.Clear();
                        salesGoodCount.Clear();
                        salesCreateDate.Clear();
                        salesId.Clear();
                    }
                    break;
                case 2:
                    {
                        if (ware1GoodId.Text == "" || ware1GoodCount.Text == "")
                        {
                            MessageBox.Show("Fill all fields");
                            return;
                        }
                        utils.Insert("insert into {0} {1} values ('{2}', {3})", 2,
                                pagesName[CurrentTabPage], tableFields[CurrentTabPage], ware1GoodId.Text, ware1GoodCount.Text);
                        MainFormUpdate();
                        ware1GoodId.Clear();
                        ware1Id.Clear();
                        ware1GoodCount.Clear();
                    }
                    break;
                case 3:
                    {
                        if (ware2GoodId.Text == "" || ware2GoodCount.Text == "")
                        {
                            MessageBox.Show("Fill all fields");
                            return;
                        }
                        utils.Insert("insert into {0} {1} values ('{2}', {3})", 3, pagesName[CurrentTabPage], tableFields[CurrentTabPage], ware2GoodId.Text, ware2GoodCount.Text);
                        MainFormUpdate();
                        ware2GoodId.Clear();
                        ware2Id.Clear();
                        ware2GoodCount.Clear();
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
                        if (nameTextBox.Text == "" || priorityTextBox.Text == "")
                        {
                            MessageBox.Show("Fill TextBox or TextBoxes you want to change");
                            return;
                        }
                        if (idTextBox.Text == "")
                        {
                            MessageBox.Show("Enter ID");
                            return;
                        }
                        utils.Update("update goods set {0} where id = {1}", 0, nameTextBox.Text, priorityTextBox.Text, idTextBox.Text);
                        MainFormUpdate();
                        nameTextBox.Clear();
                        priorityTextBox.Clear();
                        idTextBox.Clear();
                    }
                    break;
                case 1:
                    {
                        if (salesGoodId.Text == "" || salesGoodCount.Text == "" || salesCreateDate.Text == "")
                        {
                            MessageBox.Show("Fill TextBox or TextBoxes you want to change");
                            return;
                        }
                        if (salesId.Text == "")
                        {
                            MessageBox.Show("Enter ID");
                            return;
                        }
                        int size;
                        Int32.TryParse(salesGoodCount.Text, out size);
                        if (size < 1)
                        {
                            MessageBox.Show("Size must be more then 1");
                            return;
                        }
                        utils.Update("update sales set {0} where id = {1}", 1, salesGoodId.Text, salesGoodCount.Text, salesCreateDate.Text, salesId.Text);
                        MainFormUpdate();
                        salesGoodId.Clear();
                        salesGoodCount.Clear();
                        salesCreateDate.Clear();
                        salesId.Clear();
                    }
                    break;
                case 2:
                    {
                        if (ware1GoodId.Text == "" || ware1GoodCount.Text == "")
                        {
                            MessageBox.Show("Fill TextBox or TextBoxes you want to change");
                            return;
                        }
                        if (ware1Id.Text == "")
                        {
                            MessageBox.Show("Enter ID");
                            return;
                        }
                        utils.Update("update warehouse1 set {0} where id = {1}", 2, ware1GoodId.Text, ware1GoodCount.Text, ware1Id.Text);
                        MainFormUpdate();
                        ware1GoodId.Clear();
                        ware1GoodCount.Clear();
                        ware1Id.Clear();
                    }
                    break;
                case 3:
                    {
                        if (ware2GoodId.Text == "" || ware2GoodCount.Text == "")
                        {
                            MessageBox.Show("Fill TextBox or TextBoxes you want to change");
                            return;
                        }
                        if (ware2Id.Text == "")
                        {
                            MessageBox.Show("Enter ID");
                            return;
                        }
                        utils.Update("update warehouse2 set {0} where id = {1}", 3, ware2GoodId.Text, ware2GoodCount.Text, ware2Id.Text);
                        MainFormUpdate();
                        ware2GoodId.Clear();
                        ware2Id.Clear();
                        ware2GoodCount.Clear();
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
                        utils.Delete("delete from goods whedasdre id = {0}", idTextBox.Text);
                        MainFormUpdate();
                        nameTextBox.Clear();
                        priorityTextBox.Clear();
                        idTextBox.Clear();
                    }
                    break;
                case 1:
                    {
                        utils.Delete("delete from sales where id = {0}", salesId.Text);
                        MainFormUpdate();
                        salesGoodId.Clear();
                        salesGoodCount.Clear();
                        salesCreateDate.Clear();
                        salesId.Clear();
                    }
                    break;
                case 2:
                    {
                        utils.Delete("delete from warehouse1 where id = {0}", ware1Id.Text);
                        MainFormUpdate();
                        ware1GoodId.Clear();
                        ware1Id.Clear();
                        ware1GoodCount.Clear();
                    }
                    break;
                case 3:
                    {
                        utils.Delete("delete from warehouse2 where id = {0}", ware2Id.Text);
                        MainFormUpdate();
                        ware2GoodId.Clear();
                        ware2Id.Clear();
                        ware2GoodCount.Clear();
                    }
                    break;
                default:
                    break;
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form viewForm = new ViewForm("users_table");
            viewForm.Show();
        }

        //find button
        private void idFindButton_Click(object sender, EventArgs e)
        {
            switch (CurrentTabPage)
            {
                case 0:
                    {
                        DataGridViewCell selectedRow = utils.GetIndexOfIdInTable(idFindTextBox.Text, goodsGridView);
                        if (selectedRow == null)
                        {
                            MessageBox.Show("No such good in goods");
                        }
                        goodsGridView.CurrentCell = selectedRow;
                    }
                    break;
                case 1:
                    {
                        DataGridViewCell selectedRow = utils.GetIndexOfIdInTable(idFindTextBox.Text, salesGridView);
                        if (selectedRow == null)
                        {
                            MessageBox.Show("No such good in goods");
                        }
                        salesGridView.CurrentCell = selectedRow;
                    }
                    break;
                case 2:
                    {
                        DataGridViewCell selectedRow = utils.GetIndexOfIdInTable(idFindTextBox.Text, warehouse1GridView);
                        if (selectedRow == null)
                        {
                            MessageBox.Show("No such good in goods");
                        }
                        warehouse1GridView.CurrentCell = selectedRow;
                    }
                    break;
                case 3:
                    {
                        DataGridViewCell selectedRow = utils.GetIndexOfIdInTable(idFindTextBox.Text, warehouse2GridView);
                        if (selectedRow == null)
                        {
                            MessageBox.Show("No such good in goods");
                        }
                        warehouse2GridView.CurrentCell = selectedRow;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
