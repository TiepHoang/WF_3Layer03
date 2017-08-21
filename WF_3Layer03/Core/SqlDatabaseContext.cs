using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SqlDatabaseContext
    {
        public SqlConnection Connection { get; private set; }

        public SqlDatabaseContext(SqlConnection connection)
        {
            Connection = connection;
        }

        public List<string> GetAllDatatable()
        {
            List<string> lst = new List<string>();
            var dt = new SqlProvider().GetData("SELECT name FROM master.dbo.sysdatabases", Connection);
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lst.Add((string)item["name"]);
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

        public List<InfoColumnObject> GetInfoTable(string nameTable)
        {
            var dt = new SqlProvider().GetData($@"select COLUMN_NAME , DATA_TYPE , CHARACTER_MAXIMUM_LENGTH ,  COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') as IsIdentity
                                                        from INFORMATION_SCHEMA.COLUMNS
                                                        where TABLE_NAME = N'{nameTable}'", Connection);
            if (dt == null || dt.Rows.Count <= 0) return null;
            List<InfoColumnObject> lst = new List<InfoColumnObject>();
            var ListKey = GetKeyOfTable(nameTable);
            foreach (DataRow item in dt.Rows)
            {
                int d = 0;
                var ob = new InfoColumnObject();
                ob.Name = item["COLUMN_NAME"].ToString();
                ob.Type = item["DATA_TYPE"].ToString();
                ob.Length = int.TryParse(item["CHARACTER_MAXIMUM_LENGTH"].ToString(), out d) ? d == -1 ? "MAX" : d.ToString() : null;
                ob.isIdentity = item["IsIdentity"].ToString().Equals("1");
                ob.isPK = ListKey != null && ListKey.Any(q => q.Equals(ob.Name));
                lst.Add(ob);
            }
            return lst;
        }

        public List<string> GetKeyOfTable(string nameTable)
        {
            var dt = new SqlProvider().GetData($@"SELECT Col.Column_Name from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab,
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col
WHERE
    Col.Constraint_Name = Tab.Constraint_Name
    AND Col.Table_Name = Tab.Table_Name
    AND Constraint_Type = 'PRIMARY KEY'
    AND Col.Table_Name = N'{nameTable}' ", Connection);
            if (dt == null || dt.Rows.Count <= 0) return null;
            List<string> lst = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(item[0].ToString());
            }
            return lst;
        }
    }
}
