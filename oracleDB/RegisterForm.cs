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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtils.ExecuteCommand("insert into users (username, password) values ('{0}', '{1}')", loginTextBox.Text, passwordTextBox.Text);
                this.Close();
            }
            catch (OracleException)
            {
                MessageBox.Show("some exception");
            }
            
        }
    }
}
