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
    class DBUtils
    {
        public static OracleConnection con;

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
            string host = "127.0.0.1";
            int port = 1521;
            string sid = "xe";
            string userName = "c##test2";
            string pass = "mypass";

            con = getDBConnection(host, port, sid, userName, pass);
        }

        public static OracleDataAdapter SelectAdapter(string command)
        {
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(command, con);
            con.Close();
            return adapter;
        }

        public static void ExecuteCommand(string command, params object[] args)
        {
            string com = String.Format(command, args);
            using (OracleCommand cmd = new OracleCommand(com, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static OracleDataReader ReturnDataReaderForLogin(string login, string pass)
        {
            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.CommandText = String.Format("select * from users_table where username = '{0}' and user_password = '{1}'", login, pass);
            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader();
            return dr;
        }

        public static void ExecuteReaderToComboBox(string command, ComboBox cb)
        {
            using (OracleCommand cmd = new OracleCommand(command, con))
            {
                con.Open();
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        string viewName = dr["view_name"].ToString();
                        cb.Items.Add(viewName);
                    }
                }
                con.Close();
            }
        }

        public static string GetDbmsOutputLine(string nameOfProcedure, bool customCommand=false)
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

        public static void PushConnectionClose()
        {
            con.Close();
        }
    }
}
