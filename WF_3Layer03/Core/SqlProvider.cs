using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Core
{
    public class SqlProvider
    {
        public string CreatConnectString(string sServer, string sDatabase, string sUsername, string sPassword)
        {
            string result = @"Data Source=" + sServer;
            if (sDatabase != null && sDatabase.Trim().Length > 0)
            {
                result += ";Initial Catalog=" + sDatabase;
            }
            if (sUsername != null)
            {
                result += string.Format(";User ID={0};Password={1}", sUsername, sPassword);
            }
            else
            {
                result += ";Integrated Security=True";
            }
            return result;
        }

        public DataTable GetData(string query, SqlConnection connection)
        {
            using (SqlDataAdapter _da = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                _da.Fill(dt);
                return dt;
            }
        }

        public int ExecuteQuery(string query, SqlConnection connection)
        {
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                int k = 0;
                if (connection.State != ConnectionState.Open) connection.Open();
                k = cmd.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed) connection.Close();
                return k;
            }
        }

        public DataTable GetAllProc(string nameDatabase, SqlConnection connection)
        {
            return GetData($@"select SPECIFIC_NAME from {nameDatabase}.information_schema.routines 
 where routine_type = 'PROCEDURE' AND SPECIFIC_NAME NOT like 'sp_%diagram%'", connection);
        }

        public bool DropAllProc(SqlConnection connection)
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(connection.ConnectionString);
            if (string.IsNullOrWhiteSpace(b.InitialCatalog)) return false;
            ExecuteQuery($@"declare @procName varchar(500)
declare cur cursor for select SPECIFIC_NAME from {b.InitialCatalog}.information_schema.routines 
	where routine_type = 'PROCEDURE' AND SPECIFIC_NAME NOT like 'sp_%diagram%'
open cur
fetch next from cur into @procName
while @@fetch_status = 0
begin
    exec('drop procedure [' + @procName + ']')
    fetch next from cur into @procName
end
close cur
deallocate cur
", connection);
            return true;
        }

        public List<InfoColumnObject> GetTableJoin(string nameTable, SqlConnection connection)
        {
            var dt = GetData($@"select replace(CONSTRAINT_NAME,'FK_'+TABLE_NAME+'_','') as NameTableJoin ,COLUMN_NAME as KeyJoin  from INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME ='{nameTable}' 
and CONSTRAINT_NAME like 'FK_%'", connection);
            var lstTable = new List<InfoColumnObject>();
            if (dt != null && dt.Rows.Count > 0)
            {
                var allTable = new SqlDatabaseContext(connection).GetTable();
                foreach (DataRow item in dt.Rows)
                {
                    var tbl = new InfoColumnObject()
                    {
                        isFK = true,
                        NameTableJoin = item["NameTableJoin"].ToString(),
                        Name = item["KeyJoin"].ToString()
                    };
                    int k = 0;
                    while (tbl.NameTableJoin.Length > 0 && !allTable.Any(q => q.Equals(tbl.NameTableJoin)))
                    {
                        if (int.TryParse(tbl.NameTableJoin[tbl.NameTableJoin.Length - 1].ToString(), out k))
                        {
                            tbl.NameTableJoin = tbl.NameTableJoin.Remove(tbl.NameTableJoin.Length - 1, 1);
                        }
                    }
                    lstTable.Add(tbl);
                }
            }
            return lstTable;
        }
    }
}
