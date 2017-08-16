using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Setting
    {
        public string Format_NameSpace_BUS { get; set; }
        public string Format_NameSpace_DAL { get; set; }
        public string Format_NameSpace_DTO { get; set; }

        public string Format_class_BUS { get; set; }
        public string Format_class_DAL { get; set; }
        public string Format_class_DTO { get; set; }

        public string Format_PROC { get; set; }

        //[NonSerialized]
        public Hashtable Replace_Table { get; set; }

        public void Save(string path)
        {
            new Document().SaveObject<Setting>(this, path);
        }

        public Setting Read(string path)
        {
            return new Document().GetObject<Setting>(path);
        }

        public string GetNameTable(string table)
        {
            foreach (DictionaryEntry item in Replace_Table)
            {
                table = table.Replace(item.Key.ToString(), item.Value.ToString());
            }
            return table;
        }

        public string GetNamespaceBus(string table)
        {
            return string.Format(Format_NameSpace_BUS, GetNameTable(table));
        }

        public string GetNamespaceDal(string table)
        {
            return string.Format(Format_NameSpace_DAL, GetNameTable(table));
        }

        public string GetNamespaceDto(string table)
        {
            return string.Format(Format_NameSpace_DTO, GetNameTable(table));
        }

        public string GetNameProc(string table)
        {
            return string.Format(Format_PROC, GetNameTable(table));
        }

        public string GetClassBus(string table)
        {
            return string.Format(Format_class_BUS, GetNameTable(table));
        }

        public string GetClassDal(string table)
        {
            return string.Format(Format_class_DAL, GetNameTable(table));
        }

        public string GetClassDto(string table)
        {
            return string.Format(Format_class_DTO, GetNameTable(table));
        }
    }
}
