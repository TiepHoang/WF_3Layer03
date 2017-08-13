using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InfoServer
    {
        public string NameServer { get; set; }
        public bool UseAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public void Save(string path)
        {
            Security security = new Security();
            InfoServer info = new InfoServer()
            {
                Username = security.MaHoa(this.Username),
                Database = security.MaHoa(this.Database),
                Password = security.MaHoa(security.MaHoa(this.Password)),
                NameServer = this.NameServer,
                UseAccount = this.UseAccount
            };
            new Document().SaveObject<InfoServer>(info, path);
        }

        public InfoServer Read(string path)
        {
            var ob = new Document().GetObject<InfoServer>(path);
            if (ob != null)
            {
                Security security = new Security();
                this.Username = security.GiaiMa(ob.Username);
                this.Database = security.GiaiMa(ob.Database);
                this.Password = security.GiaiMa(security.GiaiMa(ob.Password));
                this.NameServer = ob.NameServer;
                this.UseAccount = ob.UseAccount;
                return this;
            }
            return null;
        }

        public Setting ReadSetting()
        {
            throw new NotImplementedException();
        }

        public List<string> ReadServer()
        {
            throw new NotImplementedException();
        }

        public InfoServer ReadInfoServer()
        {
            throw new NotImplementedException();
        }
    }
}
