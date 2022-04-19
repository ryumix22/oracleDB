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
using oracleDB.crypto;

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
                Crypto.hashPassword(LoginBox.Text);
                OracleDataReader dr = DBUtils.ReturnDataReaderForLogin(LoginBox.Text);
                if (dr.HasRows)
                {
                    dr.Read();
                    string pass = dr.GetString(1);
                    if (Crypto.checkPassword(pass, PassBox.Text))
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
                        MessageBox.Show("Wrong password");
                    }
                }
                else
                {
                    DBUtils.PushConnectionClose();
                    MessageBox.Show("No such user");
                }
            }
            else
            {
                MessageBox.Show("Please, enter login and password");
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Form regForm = new RegisterForm();
            regForm.Show();
        }
    }
}
