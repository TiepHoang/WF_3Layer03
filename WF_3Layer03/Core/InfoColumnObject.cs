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
        public bool IsPK { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsFK { get; set; }
        public string NameTableJoin { get; set; }

        public InfoColumnObject()
        {
            IsFK = false;
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
                case "time":
                    s = typeof(TimeSpan).ToString();
                    break;
                case "tityint":
                    s = typeof(byte).ToString();
                    break;
                default:
                    s = "string";
                    break;
            }
            if (!(s.Equals("string") || s.Equals(typeof(bool).ToString()) || IsPK))
            {
                s += "?";
            }
            return s;
        }

        public override string ToString()
        {
            return $"Name: {Name}     \tType: {Type}      \tLength: {Length}      \tPK: {IsPK}     \tIsIdentity: {IsIdentity}      \tFK: {IsFK}    \tNameTableJoin: {NameTableJoin}";
        }
    }
}
