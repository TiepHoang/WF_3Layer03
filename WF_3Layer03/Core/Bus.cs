using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Bus : Bussiness
    {
        private readonly string cDto;
        private readonly string cDal;

        public Bus(string nameTable, SqlConnection connection, Setting setting) : base(nameTable, connection, setting)
        {
            cDto = Setting.GetClassDto(NameTable);
            cDal = Setting.GetClassDal(NameTable);
        }

        public override string GetCode()
        {
            return $@"
using {Setting.GetNamespaceDal(NameTable)};
using {Setting.GetNamespaceDto(NameTable)};
using System;
using System.Collections.Generic;
namespace {Setting.GetNamespaceBus(NameTable)}
{'{'}
    public class {Setting.GetClassBus(NameTable)}
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

        private string Get_GetAll()
        {
            return $@"
public List<{cDto}> {GetNameMethod(eMethod.GetAll)}()
{'{'}
    return new {cDal}().{GetNameMethod(eMethod.GetAll)}();
{'}'}
";
        }

        private string Get_GetBy()
        {
            if (LstInfoTable.Count(q => q.isKey) < 2) return string.Empty;
            var lstKey = LstInfoTable.Where(q => q.isKey).ToList();
            string param = null;
            string value = null;
            string result = "";
            foreach (var item in lstKey)
            {
                value = item.Name;
                param = $"{item.GetTypeCs()} {item.Name}";
                result += $@"
public List<{cDto}> {GetNameMethod(eMethod.GetBy)}{item.Name}({param})
{'{'}
    return new {cDal}().{GetNameMethod(eMethod.GetBy)}{item.Name}({value});
{'}'}
";
            }
            return result;
        }

        private string Get_Insert()
        {
            return $@"
public bool {GetNameMethod(eMethod.Insert)}({cDto} ob)
{'{'}
    return new {cDal}().{GetNameMethod(eMethod.Insert)}(ob);
{'}'}
";
        }

        private string Get_Delete()
        {
            if (!LstInfoTable.Any(q => q.isKey)) return string.Empty;
            var lstKey = LstInfoTable.Where(q => q.isKey).ToList();
            string param = null;
            string value = null;
            bool isFirst = true;
            foreach (var item in lstKey)
            {
                string s = isFirst ? "" : ",";
                value += s + item.Name;
                param += $"{s}{item.GetTypeCs()} {item.Name}";
                isFirst = false;
            }
            return $@"
public bool {GetNameMethod(eMethod.Delete)}({param})
{'{'}
    return new {cDal}().{GetNameMethod(eMethod.Delete)}({value});
{'}'}
";
        }

//        private string Get_DeleteBy()
//        {
//            if (LstInfoTable.Count(q => q.isKey) < 2) return string.Empty;
//            var lstKey = LstInfoTable.Where(q => q.isKey).ToList();
//            string param = null;
//            string value = null;
//            string result = "";
//            foreach (var item in lstKey)
//            {
//                value = item.Name;
//                param = $"{item.GetTypeCs()} {item.Name}";
//                result += $@"
//public bool {GetNameMethod(eMethod.DeleteBy)}{item.Name}({param})
//{'{'}
//    return new {cDal}().{GetNameMethod(eMethod.DeleteBy)}{item.Name}({value});
//{'}'}
//";
//            }
//            return result;
//        }

        private string Get_Update()
        {
            if (!LstInfoTable.Any(q => q.isKey)) return string.Empty;
            return $@"
public bool Update({cDto} ob)
{'{'}
    return new {cDal}().Update(ob);
{'}'}
";
        }

        public override string GetNameClass()
        {
            return Setting.GetClassBus(NameTable);
        }

        public override string GetNameMethod(eMethod method)
        {
            return method.ToString();
        }

        public override ResultRunCode Run()
        {
            Save(Setting.Format_Basic.FolderSave_Bus);
            return new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.Success
            };
        }
    }
}
