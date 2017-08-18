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
        public class Basic
        {
            public string Format_NameSpace_BUS { get; set; }
            public string Format_NameSpace_DAL { get; set; }
            public string Format_NameSpace_DTO { get; set; }

            public string Format_class_BUS { get; set; }
            public string Format_class_DAL { get; set; }
            public string Format_class_DTO { get; set; }

            public string Format_PROC { get; set; }

            public string FolderSave_Bus { get; set; }
            public string FolderSave_Dal { get; set; }
            public string FolderSave_Dto { get; set; }

            public Basic()
            {
                Format_class_BUS = "{0}BCL";
                Format_class_DAL = "{0}Dao";
                Format_class_DTO = "{0}Object";
                Format_NameSpace_BUS = "{0}BCL";
                Format_NameSpace_DAL = "{0}Dao";
                Format_NameSpace_DTO = "{0}Object";
                Format_PROC = "WEB_01_sp_{0}_GetAll";
                FolderSave_Bus = "";
                FolderSave_Dal = "";
                FolderSave_Dto = "";
            }
        }

        public Basic Format_Basic { get; set; }

        public Hashtable Replace_Table { get; set; }

        public Setting()
        {
            Format_Basic = new Basic();
            Replace_Table = new Hashtable();
        }

        public void Save(string path)
        {
            new Document().SaveObject<Setting.Basic>(this.Format_Basic, path);
        }

        public Setting Read(string path)
        {
            var basic = new Document().GetObject<Setting.Basic>(path);
            Setting r = null;
            if (basic != null)
            {
                r = new Setting();
                r.Format_Basic = basic;
                r.Replace_Table = new Hashtable();
            }
            return r;
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
            return string.Format(Format_Basic.Format_NameSpace_BUS, GetNameTable(table));
        }

        public string GetNamespaceDal(string table)
        {
            return string.Format(Format_Basic.Format_NameSpace_DAL, GetNameTable(table));
        }

        public string GetNamespaceDto(string table)
        {
            return string.Format(Format_Basic.Format_NameSpace_DTO, GetNameTable(table));
        }

        public string GetNameProc(string table)
        {
            return string.Format(Format_Basic.Format_PROC, GetNameTable(table));
        }

        public string GetClassBus(string table)
        {
            return string.Format(Format_Basic.Format_class_BUS, GetNameTable(table));
        }

        public string GetClassDal(string table)
        {
            return string.Format(Format_Basic.Format_class_DAL, GetNameTable(table));
        }

        public string GetClassDto(string table)
        {
            return string.Format(Format_Basic.Format_class_DTO, GetNameTable(table));
        }
    }
}
