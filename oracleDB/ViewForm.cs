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
            using (OracleDataAdapter adapter = DBUtils.SelectAdapter(String.Format("select * from {0}", selectedText)))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                viewGridView.DataSource = dt;
            }
        }
    }
}
