using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InfoTableObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public bool isKey { get; set; }
        public bool isIdentity { get; set; }
    }
}
