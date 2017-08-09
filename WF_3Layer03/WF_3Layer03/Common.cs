using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_3Layer03
{
    public static class Common
    {
        public static SqlConnection connection { get; private set; }

        public static SqlConnection ChaneConnection(string sConnect)
        {
            connection = new SqlConnection(sConnect);
            return connection;
        }

        public const string FILE_INFOSERVER = "system.infoserver.xml";

        public const string FILE_SERVER = "system.server.txt";

    }
}
