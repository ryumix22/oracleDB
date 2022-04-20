using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace oracleDB
{
    public class DBUtils
    {
        public static OracleConnection con { get; set; }

        private static OracleConnection getDBConnection(string host, int port, string sid, string user, string password)
        {

            Console.WriteLine("Getting Connection ...");

            // Connection String для прямого подключения к Oracle.
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;


            OracleConnection conn = new OracleConnection
            {
                ConnectionString = connString
            };

            return conn;
        }

        public static void CreateConnection()
        {
            //string host = "192.168.56.101";
            string host = "127.0.0.1";
            int port = 1521;
            string sid = "xe";
            string userName = "c##test2";
            string pass = "mypass";

            con = getDBConnection(host, port, sid, userName, pass);
        }

        public static OracleDataAdapter SelectAdapter(string command)
        {
            try
            {
                con.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(command, con);
                con.Close();
                return adapter;
            }
            catch (OracleException)
            {
                MessageBox.Show("No connection with DataBase");
                throw new ApplicationException("No connection with DataBase");
            }
        }

        public static void ExecuteCommand(string command, params object[] args)
        {
            string com = String.Format(command, args);
            using (OracleCommand cmd = new OracleCommand(com, con))
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (OracleException)
                {
                    MessageBox.Show("No connection with DataBase");
                    throw new ApplicationException("No connection with DataBase");
                }
            }
        }

        public static bool CheckForLogin(string login)
        {
            string com = String.Format("select username from users_table where username = '{0}'", login);

            using (OracleCommand cmd = new OracleCommand(com, con))
            {
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
                catch (OracleException)
                {
                    MessageBox.Show("No connection with DataBase");
                    throw new ApplicationException("No connection with DataBase");
                }
            }
        }

        public static OracleDataReader ReturnDataReaderForLogin(string login)
        {
            string com = String.Format("select * from users_table where username = '{0}'", login);
            
            using (OracleCommand cmd = new OracleCommand(com, con))
            {
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    return dr;
                }
                catch (OracleException)
                {
                    MessageBox.Show("No connection with DataBase");
                    throw new ApplicationException("No connection with DataBase");
                }
            }
        }

        public static void ExecuteReaderToComboBox(string command, ComboBox cb)
        {
            using (OracleCommand cmd = new OracleCommand(command, con))
            {
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string viewName = dr["view_name"].ToString();
                            cb.Items.Add(viewName);
                        }
                    }
                    con.Close();
                }
                catch (OracleException)
                {
                    MessageBox.Show("No connection with DataBase");
                    throw new ApplicationException("No connection with DataBase");
                }
            }
        }

        public static string GetDbmsOutputLine(string nameOfProcedure, bool customCommand=false)
        {
            try
            {
                con.Open();
                string command;
                if (!customCommand)
                {
                    command = "begin " + nameOfProcedure + "; end;";
                }
                else
                {
                    command = nameOfProcedure;
                }
                using (OracleCommand cmd = new OracleCommand(command, con))
                {
                    cmd.CommandText = "BEGIN DBMS_OUTPUT.ENABLE(NULL); END;";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.Text;
                    var res = cmd.ExecuteNonQuery();

                    cmd.CommandText = "BEGIN DBMS_OUTPUT.GET_LINES(:outString, :numLines); END;";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add(new OracleParameter("outString", OracleDbType.Varchar2, int.MaxValue, ParameterDirection.Output));
                    cmd.Parameters["outString"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    cmd.Parameters["outString"].Size = command.Length;
                    cmd.Parameters["outString"].ArrayBindSize = new int[command.Length];

                    // set bind size for each array element
                    for (int i = 0; i < command.Length; i++)
                    {
                        cmd.Parameters["outString"].ArrayBindSize[i] = 32000;
                    }


                    cmd.Parameters.Add(new OracleParameter("numLines", OracleDbType.Int32, ParameterDirection.InputOutput));
                    cmd.Parameters["numLines"].Value = 10; // Get 10 lines
                    cmd.ExecuteNonQuery();

                    int numLines = Convert.ToInt32(cmd.Parameters["numLines"].Value.ToString());
                    string outString = string.Empty;

                    // Try to get more lines until there are zero left
                    while (numLines > 0)
                    {
                        for (int i = 0; i < numLines; i++)
                        {
                            // use proper indexing here
                            //OracleString s = (OracleString)cmd.Parameters["outString"].Value;
                            OracleString s = ((OracleString[])cmd.Parameters["outString"].Value)[i];
                            outString += s.ToString();

                            // add new line just for formatting
                            outString += "\r\n";
                        }

                        cmd.ExecuteNonQuery();
                        numLines = Convert.ToInt32(cmd.Parameters["numLines"].Value.ToString());
                    }
                    con.Close();
                    return outString;
                }
            }
            catch (OracleException)
            {
                MessageBox.Show("No connection with DataBase");
                throw new ApplicationException("No connection with DataBase");
            }        
        }

        public static void PushConnectionClose()
        {
            try
            {
                con.Close();
            }
            catch (OracleException)
            {
                MessageBox.Show("No connection with DataBase");
                throw new ApplicationException("No connection with DataBase");
            }
        }
    }
}
