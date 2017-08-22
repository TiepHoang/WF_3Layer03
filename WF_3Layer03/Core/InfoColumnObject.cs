using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InfoColumnObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public bool isPK { get; set; }
        public bool isIdentity { get; set; }
        public bool isFK { get; set; }
        public string NameTableJoin { get; set; }

        public InfoColumnObject()
        {
            isFK = false;
        }

        public string GetTypeCs()
        {
            string s = "";
            switch (Type)
            {
                case "int":
                    s = typeof(int).ToString();
                    break;
                case "uniqueidentifier":
                    s = typeof(Guid).ToString();
                    break;
                case "float":
                    s = typeof(double).ToString();
                    break;
                case "bit":
                    s = typeof(bool).ToString();
                    break;
                case "money":
                    s = typeof(decimal).ToString();
                    break;
                case "date":
                case "datetime":
                    s = typeof(DateTime).ToString();
                    break;
                default:
                    s = "string";
                    break;
            }
            if (!(s.Equals("string") || s.Equals(typeof(bool).ToString()) || isPK))
            {
                s += "?";
            }
            return s;
        }

        public override string ToString()
        {
            return $"Name: {Name}     \tType: {Type}      \tLength: {Length}      \tPK: {isPK}     \tIsIdentity: {isIdentity}      \tFK: {isFK}    \tNameTableJoin: {NameTableJoin}";
        }
    }
}
