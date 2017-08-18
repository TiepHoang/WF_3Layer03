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
        public List<InfoTableObject> LstInfoTable { get; protected set; }
        public string NameTable { get; protected set; }
        public Setting Setting { get; protected set; }
        public Dictionary<string,string> Map { get; protected set; }

        public enum eMethod
        {
            GetAll,
            Insert,
            Delete,
            Update,
            GetBy,
            DeleteBy
        }

        public Bussiness(string nameTable, SqlConnection connection, Setting setting)
        {
            NameTable = NameTable;
            Setting = setting;
            LstInfoTable = new SqlDatabaseContext(connection).GetInfoTable(nameTable);
            Map = new Dictionary<string, string>();
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
