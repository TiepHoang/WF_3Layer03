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
            proc = new Proc(sTable, connection, setting);
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
            if (!LstInfoTable.Any(q => q.IsPK) || LstInfoTable.Count == LstInfoTable.Count(q => q.IsPK)) return "";
            string passValue = "";
            bool isFirst = true;
            foreach (var item in LstInfoTable)
            {
                string s = isFirst ? "" : ",";
                passValue += $@"{s} ob.{item.Name.Replace(' ', '_')} ";
                isFirst = false;
            }
            return $@"
public int {GetNameMethod(eMethod.Update)}({cDto} ob)
{'{'}
    return new {dbEntity}().{proc.GetName(eMethod.Update)[0]}({passValue});
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
            var ls = LstInfoTable.Where(q => q.IsPK).ToList();
            string param = "";
            string value = "";
            bool isFirst = true;
            string s = "";
            if (ls.Count > 1)
            {
                foreach (var item in ls)
                {
                    s = isFirst ? "" : ",";
                    param += $"{s} {item.GetTypeCs()} {item.Name}";
                    value += $"{s} {item.Name}";
                    isFirst = false;
                }
            }
            else
            {
                foreach (var item in ls)
                {
                    s = isFirst ? "" : ",";
                    param += $"{s} object {item.Name}";
                    value += $"{s}({item.GetTypeCs()}) {item.Name}";
                    isFirst = false;
                }
            }
            return $@"
    public int {GetNameMethod(eMethod.Delete)}({param})
{'{'}
    return new {dbEntity}().{proc.GetName(eMethod.Delete)[0]}({value});
{'}'}
";
        }

        private string Get_Insert()
        {
            string passValue = "";
            bool isFirst = true;
            var ls = LstInfoTable.Where(q => !q.IsIdentity).ToList();
            foreach (var item in ls)
            {
                string s = isFirst ? "" : ",";
                passValue += $@"{s} ob.{item.Name.Replace(' ', '_')} ";
                isFirst = false;
            }
            return $@"
public int {GetNameMethod(eMethod.Insert)}({cDto} ob)
{'{'}
    return new {dbEntity}().{proc.GetName(eMethod.Insert)[0]}({passValue});
{'}'}
";
        }

        private string Get_GetBy()
        {
            var lsKey = LstInfoTable.Where(q => q.IsPK).ToList();
            if (lsKey.Count < 1) return string.Empty;
            string result = "";
            for (int i = 0; i < lsKey.Count; i++)
            {
                var itemKey = lsKey[i];
                string setValue = "";
                foreach (var v in LstInfoTable)
                {
                    string checkBool = v.GetTypeCs() == typeof(bool).ToString() ? "== true" : "";
                    setValue += $@"
obj.{v.Name.Replace(' ', '_')} = item.{v.Name.Replace(' ', '_')} {checkBool} ;";
                }

                foreach (var fk in Table.lstFK)
                {
                    var tblJoin = new TableObject(fk.NameTableJoin, Connection);
                    string sDto = Setting.GetClassDto(tblJoin.Name);
                    string stableJoin = $"_{Setting.GetNameTable(tblJoin.Name)}Join";
                    string passValueJoin = "";
                    for (int j = 0; j < tblJoin.lstColumns.Count; j++)
                    {
                        var co = tblJoin.lstColumns[j];
                        string cm = j == tblJoin.lstColumns.Count - 1 ? "" : ",";
                        string checkBool = co.GetTypeCs() == typeof(bool).ToString() ? "== true" : "";
                        string checkFK = stableJoin;
                        string checkNullable = "";
                        string nameEntty = co.Name.Replace(' ', '_');
                        if (co.IsPK)
                        {
                            checkFK = "";
                            checkNullable = $"({co.GetTypeCs()})";
                            nameEntty = fk.Name.Replace(' ', '_');
                        }
                        passValueJoin += $@"
        {co.Name.Replace(' ', '_')} = {checkNullable} item.{nameEntty}{checkFK} {checkBool} {cm}";
                    }
                    setValue += $@"
obj.{sDto}Join = new {sDto}()
{'{'}
    {passValueJoin}
{'}'};
";
                }
                result += $@"
public {cDto} {GetNameMethod(eMethod.GetBy)}{itemKey.Name}({itemKey.GetTypeCs()} {itemKey.Name})
{'{'}
    var list =  new {dbEntity}().{proc.GetName(eMethod.GetBy)[i]}({itemKey.Name});
    foreach (var item in list)
    {'{'}
        var obj = new {cDto}();
        {setValue}
        return obj;
    {'}'}
    return null;
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
                string checkBool = item.GetTypeCs() == typeof(bool).ToString() ? "== true" : "";
                passValue += $@"
obj.{item.Name.Replace(' ', '_')} = item.{item.Name.Replace(' ', '_')} {checkBool} ;";
            }
            foreach (var itemFK in Table.lstFK)
            {
                var tblJoin = new TableObject(itemFK.NameTableJoin, Connection);
                string sDto = Setting.GetClassDto(tblJoin.Name);
                string stableJoin = itemFK.IsPK ? "" : $"_{Setting.GetNameTable(tblJoin.Name)}Join";
                string passValueJoin = "";
                for (int i = 0; i < tblJoin.lstColumns.Count; i++)
                {
                    var co = tblJoin.lstColumns[i];
                    string cm = i == tblJoin.lstColumns.Count - 1 ? "" : ",";
                    string checkBool = co.GetTypeCs() == typeof(bool).ToString() ? "== true" : "";
                    string checkFK = stableJoin;
                    string checkNullable = "";
                    string nameEntty = co.Name.Replace(' ', '_');
                    if (co.IsPK)
                    {
                        checkFK = "";
                        checkNullable = $"({co.GetTypeCs()})";
                        nameEntty = itemFK.Name.Replace(' ', '_');
                    }
                    passValueJoin += $@"
        {co.Name.Replace(' ', '_')} = {checkNullable}item.{nameEntty}{checkFK} {checkBool} {cm}";
                }
                passValue += $@"
obj.{sDto}Join = new {sDto}()
{'{'}
    {passValueJoin}
{'}'};
";
            }
            return $@"
public List<{cDto}> {GetNameMethod(eMethod.GetAll)}()
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
            if (method == eMethod.Insert) return "Add";
            return method.ToString();
        }

        public override ResultRunCode Run()
        {
            Save(Setting.Format_Basic.FolderSave_Dal);
            return new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.Success,
                Message = $"{GetNameClass()} : Saved in {Setting.Format_Basic.FolderSave_Dal}"
            };
        }
    }
}
