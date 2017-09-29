using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TableObject
    {
        public SqlConnection Connection { get; private set; }
        public string Name { get; private set; }
        public List<InfoColumnObject> lstColumns { get; private set; }
        public List<InfoColumnObject> lstFK { get; private set; }

        public TableObject(string nameTable, SqlConnection connection)
        {
            this.Name = nameTable;
            this.Connection = connection;
            lstColumns = new SqlDatabaseContext(Connection).GetInfoTable(Name);
            lstFK = new SqlProvider().GetTableJoin(Name, connection);
            if (lstFK.Count > 0)
            {
                lstFK.OrderBy(q => q.Name).ToList();
                foreach (var item in lstFK)
                {
                    var col = lstColumns.First(q => q.Name.Equals(item.Name));
                    col.IsFK = item.IsFK;
                    col.NameTableJoin = item.NameTableJoin;
                }
            }
        }
    }
}
