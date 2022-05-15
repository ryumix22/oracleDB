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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                try
                {
                    if (DBUtils.CheckForLogin(loginTextBox.Text))
                    {
                        MessageBox.Show("Such user is already created");
                        return;
                    }
                    if (loginTextBox.Text.Length > 20)
                    {
                        MessageBox.Show("Login is to big. Must be less then 20 symbols");
                        return;
                    }
                    if (passwordTextBox.Text.Length > 20)
                    {
                        MessageBox.Show("Password is to big. Must be less then 20 symbols");
                        return;
                    }
                    if (passwordTextBox.Text.Length < 6)
                    {
                        MessageBox.Show("Password is to short. Must be more then 6 symbols");
                        return;
                    }
                    string hashedPassword = Crypto.hashPassword(passwordTextBox.Text);
                    DBUtils.ExecuteCommand("insert into users_table (username, user_password) values ('{0}', '{1}')", loginTextBox.Text, hashedPassword);
                    this.Close();
                }
                catch (ApplicationException ex)
                {
                    DBUtils.PushConnectionClose();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please, enter login and password");
            }
        }
    }
}
