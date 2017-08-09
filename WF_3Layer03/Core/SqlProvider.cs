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
            int k = 0;
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                k = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return k;
        }
    }
}
