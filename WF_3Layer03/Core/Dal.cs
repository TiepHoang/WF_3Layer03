using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Dal : Bussiness
    {
        private readonly string cDto;
        private readonly Proc proc;
        private readonly string dbEntity;

        public Dal(string nameTable, SqlConnection connection, Setting setting) : base(nameTable, connection, setting)
        {
            cDto = setting.GetClassDto(NameTable);
            proc = new Proc(Table, connection, setting);
            dbEntity = new SqlConnectionStringBuilder(connection.ConnectionString).InitialCatalog + "Entities";
        }

        public override string GetCode()
        {
            return $@"
using System;
using System.Collections.Generic;
using {Setting.GetNamespaceDto(NameTable)};
using {Setting.Format_Basic.Namespace_Entity};

namespace {Setting.GetNamespaceDal(NameTable)}
{'{'}
    public class {Setting.GetClassDal(NameTable)}
    {'{'}
        {Get_GetAll()}
        {Get_GetBy()}
        {Get_Insert()}
        {Get_Delete()}
        {Get_Update()}
    {'}'}
{'}'}
";
        }

        private string Get_Update()
        {
            if (!LstInfoTable.Any(q => q.isKey) || LstInfoTable.Count == LstInfoTable.Count(q => q.isKey)) return "";
            string passValue = "";
            bool isFirst = true;
            foreach (var item in LstInfoTable)
            {
                string s = isFirst ? "" : ",";
                passValue += $@"{s} ob.{item.Name} ";
                isFirst = false;
            }
            return $@"
public bool {GetNameMethod(eMethod.Update)}({cDto} ob)
{'{'}
    return new {dbEntity}().{proc.GetName(eMethod.Update)[0]}({passValue})>0;
{'}'}
";
        }

        //        private string Get_DeleteBy()
        //        {
        //            var ls = LstInfoTable.Where(q => q.isKey).ToList();
        //            if (ls.Count < 2) return string.Empty;
        //            string result = "";
        //            foreach (var item in ls)
        //            {
        //                result += $@"
        //public bool {GetNameMethod(eMethod.DeleteBy)}{item.Name}({item.GetTypeCs()} {item.Name})
        //{'{'}
        //    return new {dbEntity}().{proc.GetName(eMethod.Delete)}({item.Name})>0;
        //{'}'}
        //";
        //            }
        //            return result;
        //        }

        private string Get_Delete()
        {
            var ls = LstInfoTable.Where(q => q.isKey).ToList();
            string param = "";
            string value = "";
            bool isFirst = true;
            string s = "";
            foreach (var item in ls)
            {
                s = isFirst ? "" : ",";
                param += $"{s} {item.GetTypeCs()} {item.Name}";
                value += $"{s} {item.Name}";
                isFirst = false;
            }
            return $@"
public bool {GetNameMethod(eMethod.Delete)}({param})
{'{'}
    return new {dbEntity}().{proc.GetName(eMethod.Delete)[0]}({value})>0;
{'}'}
";
        }

        private string Get_Insert()
        {
            string passValue = "";
            bool isFirst = true;
            var ls = LstInfoTable.Where(q => !q.isIdentity).ToList();
            foreach (var item in ls)
            {
                string s = isFirst ? "" : ",";
                passValue += $@"{s} ob.{item.Name} ";
                isFirst = false;
            }
            return $@"
public bool {GetNameMethod(eMethod.Insert)}({cDto} ob)
{'{'}
    return new {dbEntity}().{proc.GetName(eMethod.Insert)[0]}({passValue})>0;
{'}'}
";
        }

        private string Get_GetBy()
        {
            var ls = LstInfoTable.Where(q => q.isKey).ToList();
            if (ls.Count < 2) return string.Empty;
            string result = "";
            for (int i = 0; i < ls.Count; i++)
            {
                var item = ls[i];
                string setValue = "";
                foreach (var v in LstInfoTable)
                {
                    setValue = $@"
obj.{v.Name} = item.{item.Name};";
                }
                result += $@"
public List<{cDto}> {GetNameMethod(eMethod.GetBy)}{item.Name}({item.GetTypeCs()} {item.Name})
{'{'}
    var list =  new {dbEntity}().{proc.GetName(eMethod.GetBy)[i]}({item.Name});
    List<{cDto}> lst = new List<{cDto}>();
    foreach (var item in list)
    {'{'}
        var obj = new {cDto}();
        {setValue}
        lst.Add(obj);
    {'}'}
    return lst;
{'}'}
";
            }
            return result;
        }

        private string Get_GetAll()
        {
            string passValue = "";
            foreach (var item in LstInfoTable)
            {
                passValue += $@"
obj.{item.Name} = item.{item.Name};";
            }
            return $@"
public List<{cDto}> {GetNameMethod(eMethod.GetAll)[0]}()
{'{'}
    var list = new {dbEntity}().{proc.GetName(eMethod.GetAll)[0]}();
    List<{cDto}> lst = new List<{cDto}>();
    foreach (var item in list)
    {'{'}
        var obj = new {cDto}();
        {passValue}
        lst.Add(obj);
    {'}'}
    return lst;
{'}'}
";
        }

        public override string GetNameClass()
        {
            return Setting.GetClassDal(NameTable);
        }

        public override string GetNameMethod(eMethod method)
        {
            return method.ToString();
        }

        public override ResultRunCode Run()
        {
            Save(Setting.Format_Basic.FolderSave_Dal);
            return new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.Success
            };
        }
    }
}
