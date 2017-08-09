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
            Security security = new Security();
            this.Username = security.MaHoa(this.Username);
            this.Password = security.MaHoa(security.MaHoa(this.Password));
            new Document().SaveObject<InfoServer>(this, path);
        }

        public InfoServer Read(string path)
        {
            var ob = new Document().GetObject<InfoServer>(path);
            if (ob != null)
            {
                Security security = new Security();
                ob.Username = security.GiaiMa(ob.Username);
                ob.Password = security.GiaiMa(security.GiaiMa(ob.Password));
                return ob;
            }
            return null;
        }
    }
}
