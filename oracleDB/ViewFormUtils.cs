using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oracleDB
{
    public class ViewFormUtils
    {
        public static DataTable GetDataTableView(string input)
        {
            try
            {
                return DBUtils.ReturnDataTable(String.Format("select * from {0}", input));
            }
            catch (ApplicationException ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
