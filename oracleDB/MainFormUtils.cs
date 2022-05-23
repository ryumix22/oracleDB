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
    public class MainFormUtils
    {
        public DataTable GetDataTable(string command)
        {
            try
            {
                return DBUtils.ReturnDataTable(command);
            }
            catch (ApplicationException ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int Insert(string command, int currentPage, params string[] p)
        {
            switch (currentPage)
            {
                case 0:
                    {
                        try
                        {
                            if (p.Length < 4)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command, p[0], p[1], p[2], p[3]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            if (p.Length < 5)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command,
                                p[0], p[1], p[2], p[3], p[4]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                case 2:
                    {
                        try
                        {
                            if (p.Length < 4)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command, p[0], p[1], p[2], p[3]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                case 3:
                    {   
                        try
                        {
                            if (p.Length < 4)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command, p[0], p[1], p[2], p[3]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public int Update(string command, int currentPage, params string[] p)
        {
            switch (currentPage)
            {
                case 0:
                    {
                        try
                        {
                            if (p.Length < 3)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command, ConfigSetString(currentPage, p[0], p[1]),
                                p[2]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            if (p.Length < 4)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command,
                                ConfigSetString(currentPage, p[0], p[1], p[2]), p[3]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                case 2:
                    {
                        try
                        {
                            if (p.Length < 3)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command,
                                ConfigSetString(currentPage, p[0], p[1]), p[2]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                case 3:
                    {
                        try
                        {
                            if (p.Length < 3)
                            {
                                return 0;
                            }
                            DBUtils.ExecuteCommand(command,
                                ConfigSetString(currentPage, p[0], p[1]), p[2]);
                            return 1;
                        }
                        catch (ApplicationException ex)
                        {
                            //MessageBox.Show(ex.Message);
                            return 0;
                        }
                    }
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public int Delete(string command, string id)
        {
            try
            {
                DBUtils.ExecuteCommand(command, id);
                return 1;
            }
            catch (ApplicationException ex)
            {
                //MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public OracleDataReader ViewComboBoxDataReader()
        {
            try
            {
                return DBUtils.ReturnDataReader("select view_name from user_views");
            }
            catch (ApplicationException)
            {
                return null;
            }
        }

        public string ConfigSetString(int currentTabPage, params string[] args)
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
                    if (fields[currentTabPage][i] == "name = ") resultString += fields[currentTabPage][i] + "'" + args[i] + "'";
                    else if (fields[currentTabPage][i] == "create_date = ") resultString += fields[currentTabPage][i] + "to_date('" + args[i] + "','DD-MM-YYYY')";
                    else resultString += fields[currentTabPage][i] + args[i];
                    resultString += ", ";
                }
            }
            resultString = resultString.Remove(resultString.Length - 2);
            return resultString;
        }

        public DataGridViewCell GetIndexOfIdInTable(string id, DataGridView currentGridView)
        {
            int columnIndex = -1;
            if (currentGridView == null) return null;
            foreach (DataGridViewColumn column in currentGridView.Columns)
            {
                if (column.Name.Equals("ID"))
                {
                    columnIndex = column.Index;
                }
            }
            if (columnIndex == -1) return null;
            foreach (DataGridViewRow row in currentGridView.Rows)
            {
                if (row.Cells[columnIndex].Value.ToString().Equals(id))
                {
                    return row.Cells[0];
                }
            }
            return null;
        }
    }
}
