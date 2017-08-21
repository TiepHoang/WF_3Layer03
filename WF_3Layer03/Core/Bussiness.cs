using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Bussiness : IAction
    {
        public List<InfoColumnObject> LstInfoTable { get; private set; }
        public string NameTable { get; private set; }
        public Setting Setting { get; private set; }
        public string sTable { get; private set; }
        public SqlConnection Connection{ get; private set; }
        public TableObject Table { get; set; }

        public enum eMethod
        {
            GetAll,
            Insert,
            Delete,
            Update,
            GetBy
        }

        public Bussiness(string nameTable, SqlConnection connection, Setting setting)
        {
            Connection = connection;
            sTable = nameTable;
            Setting = setting;
            LstInfoTable = new SqlDatabaseContext(connection).GetInfoTable(nameTable);
            NameTable = setting.GetNameTable(nameTable);
            Table = new TableObject(sTable, connection);
        }

        public abstract ResultRunCode Run();

        public virtual void Save(string path)
        {
            string s = GetNameClass();
            if (!string.IsNullOrEmpty(s))
                new Document().SaveAllText(GetCode(), path, s, ".cs");
        }

        public abstract string GetCode();

        public abstract string GetNameClass();

        public abstract string GetNameMethod(eMethod method);
    }
}
