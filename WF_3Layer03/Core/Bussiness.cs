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
        public List<InfoTableObject> ListInfoTable { get; protected set; }
        public string NameTable { get; set; }

        public enum eMethod
        {
            GetAll,
            Insert,
            Delete,
            Update,
            GetBy,
            DeleteBy
        }

        public Bussiness(string nameTable,SqlConnection connection)
        {
            NameTable = NameTable;
            ListInfoTable = new SqlDatabaseContext(connection).GetInfoTable(nameTable);
        }

        public ResultRunCode Run()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public virtual string GetName(eMethod method)
        {
            return "";
        }
    }
}
