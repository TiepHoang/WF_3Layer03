using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Setting
    {
        public string NameSpace_BUS { get; set; }
        public string NameSpace_DAL { get; set; }
        public string NameSpace_DTO { get; set; }

        public string Format_BUS { get; set; }
        public string Format_DAL { get; set; }
        public string Format_DTO { get; set; }

        public string Format_PROC { get; set; }

        public void Save(string path)
        {
            new Document().SaveObject<Setting>(this, path);
        }

        public Setting Read(string path)
        {
            return new Document().GetObject<Setting>(path);
        }
    }
}
