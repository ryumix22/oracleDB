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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            DBUtils.CreateConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text != "" && PassBox.Text != "")
            {

                OracleDataReader dr = DBUtils.ReturnDataReaderForLogin(LoginBox.Text, PassBox.Text);
                if (dr.HasRows)
                {
                    DBUtils.PushConnectionClose();
                    Form nextform = new MainForm();
                    nextform.Show();
                    nextform.FormClosed += new FormClosedEventHandler((o, a) =>
                    {
                        this.Close();
                    });
                    this.Hide();
                }
                else
                {
                    DBUtils.PushConnectionClose();
                    MessageBox.Show("no such user");
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Form regForm = new RegisterForm();
            regForm.Show();
        }
    }
}
