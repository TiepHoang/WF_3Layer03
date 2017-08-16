using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SqlDatabaseConext
    {
        public SqlConnection Connection { get; private set; }

        public SqlDatabaseConext(SqlConnection connection)
        {
            Connection = connection;
        }

        public List<string> GetAllDatatable()
        {
            List<string> lst = new List<string>();
            var dt = new SqlProvider().GetData("EXEC sp_databases", Connection);
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lst.Add((string)item["DATABASE_NAME"]);
                }
                lst = lst.OrderBy(q => q).ToList();
            }
            return lst;
        }

        public List<string> GetTable()
        {
            List<string> lst = new List<string>();
            var dt = new SqlProvider().GetData("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", Connection);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lst.Add((string)item["TABLE_NAME"]);
                }
                lst = lst.OrderBy(q => q).ToList();
            }
            return lst;
        }
    }
}
