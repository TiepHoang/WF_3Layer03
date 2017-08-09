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

        public void Save(string path)
        {
            new Document().SaveObject<InfoServer>(this, path);
        }

        public InfoServer Read(string path)
        {
            var ob = new Document().GetObject<InfoServer>(path);
            this.NameServer = ob.NameServer;
            this.UseAccount = ob.UseAccount;
            this.Username = ob.Username;
            this.Password = ob.Password;
            return this;
        }
    }
}
