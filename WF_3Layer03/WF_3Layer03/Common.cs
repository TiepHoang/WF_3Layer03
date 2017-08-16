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
        const string FILE_INFOSERVER = "system.infoserver.xml";
        const string FILE_SERVER = "system.server.txt";
        const string FILE_SETTING = "system.setting.xml";

        public static InfoServer InfoServer { get; private set; }

        public static SqlConnection connection { get; private set; }

        public static SqlConnection ChaneConnection(InfoServer infoServer)
        {
            InfoServer = infoServer;
            connection = new SqlConnection(new SqlProvider().CreatConnectString(InfoServer.NameServer, InfoServer.Database,
                InfoServer.UseAccount ? InfoServer.Username : null, InfoServer.UseAccount ? InfoServer.Password : null));
            return connection;
        }

        internal static void SaveInfoServer(InfoServer infoServer)
        {
            InfoServer = infoServer;
            InfoServer.Save(FILE_INFOSERVER);
        }

        internal static void ReadServer()
        {
            LstServer = new Document().ReadText(FILE_SERVER);
        }

        internal static void ReadSetting()
        {
            Setting = new Setting().Read(FILE_SETTING);
        }

        internal static void ReadInfoServer()
        {
            InfoServer = new InfoServer().Read(FILE_INFOSERVER);
        }

        public static Setting Setting { get; set; }

        public static List<string> LstServer { get; set; }

        internal static void AddListServer(string text)
        {
            LstServer.Add(text);
            new Document().SaveText(LstServer, "/", FILE_SERVER, null);
        }

        internal static void SaveSetting()
        {
            Setting.Save(FILE_SETTING);
        }
    }
}
