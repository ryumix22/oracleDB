using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using oracleDB.crypto;
using System.Windows.Forms;

namespace oracleDB
{
    public class LoginFormUtils
    {
        public bool isLoginExist = false;
        public bool isPasswordCorrect = false;

        public LoginFormUtils(string login, string password)
        {
            try
            {
                isLoginExist = DBUtils.CheckForLogin(login);
            }
            catch(ApplicationException ex)
            {
                throw ex;
            }

            if (isLoginExist)
            {
                string pass;
                try
                {
                    OracleDataReader dr = DBUtils.ReturnDataReaderForLogin(login);
                    dr.Read();
                    pass = dr.GetString(1);
                }
                catch (ApplicationException ex)
                {
                    throw ex;
                }

                isPasswordCorrect = Crypto.checkPassword(pass, password);
            }
            DBUtils.PushConnectionClose();
        }
    }
}
