using Core;
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
        public static InfoServer InfoServer { get; private set; }

        public static SqlConnection connection { get; private set; }

        public static SqlConnection ChaneConnection(InfoServer infoServer)
        {
            InfoServer = infoServer;
            connection = new SqlConnection(new SqlProvider().CreatConnectString(InfoServer.NameServer, InfoServer.Database,
                InfoServer.UseAccount ? InfoServer.Username : null, InfoServer.UseAccount ? InfoServer.Password : null));
            return connection;
        }

        public const string FILE_INFOSERVER = "system.infoserver.xml";

        public const string FILE_SERVER = "system.server.txt";

    }
}
