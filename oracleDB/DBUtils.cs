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
        public static OracleConnection connection { get; set; }

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
            int port = 3333;
            string sid = "xe";
            string userName = "c##test2";
            string pass = "mypass";

            connection = getDBConnection(host, port, sid, userName, pass);
        }

        public static DataTable ReturnDataTable(string command)
        {
            try
            {
                try
                {
                    connection.Open();
                }
                catch (OracleException)
                {
                    throw new ApplicationException("No connection with DataBase");
                }
                OracleDataAdapter adapter = new OracleDataAdapter(command, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                return dt;
            }
            catch (OracleException)
            {
                connection.Close();
                throw new ApplicationException("Wrong command");
            }
        }

        public static void ExecuteCommand(string command, params object[] args)
        {
            string com;
            try
            {
                com = String.Format(command, args);
            } catch (Exception)
            {
                throw new ApplicationException("Wrong Command");
            }
            using (OracleCommand cmd = new OracleCommand(com, connection))
            {
                try
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {
                        throw new ApplicationException("No connection with DataBase");
                    }
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (OracleException)
                {
                    connection.Close();
                    throw new ApplicationException("Wrong Command");
                }
            }
        }

        public static bool CheckForLogin(string login)
        {
            string com = String.Format("select username from users_table where username = '{0}'", login);

            using (OracleCommand cmd = new OracleCommand(com, connection))
            {
                try
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (OracleException)
                    {
                        throw new ApplicationException("No connection with DataBase");
                    }
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
                catch (OracleException)
                {
                    connection.Close();
                    throw new ApplicationException("Wrong Command");
                }
            }
        }

        public static OracleDataReader ReturnDataReaderForLogin(string login)
        {
            string com = String.Format("select * from users_table where username = '{0}'", login);
            
            using (OracleCommand cmd = new OracleCommand(com, connection))
            {
                try
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (OracleException)
                    {
                        throw new ApplicationException("No connection with DataBase");
                    }
                    OracleDataReader dr = cmd.ExecuteReader();
                    return dr;
                }
                catch (OracleException)
                {
                    connection.Close();
                    throw new ApplicationException("Wrong Command");
                }
            }
        }

        public static OracleDataReader ReturnDataReader(string command)
        {
            using (OracleCommand cmd = new OracleCommand(command, connection))
            {
                try
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (OracleException)
                    {
                        throw new ApplicationException("No connection with DataBase");
                    }
                    OracleDataReader dr = cmd.ExecuteReader();
                    return dr;
                }
                catch (OracleException)
                {
                    connection.Close();
                    throw new ApplicationException("Wrong Command");
                }
            }
        }

        public static string GetDbmsOutputLine(string nameOfProcedure, bool customCommand=false)
        {
            try
            {
                try
                {
                    connection.Open();
                }
                catch (OracleException)
                {
                    throw new ApplicationException("No connection with DataBase");
                }
                string command;
                if (!customCommand)
                {
                    command = "begin " + nameOfProcedure + "; end;";
                }
                else
                {
                    command = nameOfProcedure;
                }
                using (OracleCommand cmd = new OracleCommand(command, connection))
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
                    connection.Close();
                    return outString;
                }
            }
            catch (OracleException)
            {
                connection.Close();
                throw new ApplicationException("Wrong Name Of Procedure");
            }        
        }

        public static void PushConnectionClose()
        {
            try
            {
                connection.Close();
            }
            catch (OracleException)
            {
                throw new ApplicationException("Unable to Close Connection");
            }
        }
    }
}
