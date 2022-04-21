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
    public partial class ViewForm : Form
    {
        public ViewForm(string selectedText)
        {
            InitializeComponent();
            this.Text = selectedText;

            DataTable dt = ViewFormUtils.GetDataTableView(selectedText);
            viewGridView.DataSource = dt;
            if (dt == null)
            {
                MessageBox.Show("No Data avaliable for view");
            }
        }
    }
}
