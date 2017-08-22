using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Dto : Bussiness
    {
        public Dto(string nameTable, SqlConnection connection, Setting setting) : base(nameTable, connection, setting)
        {
        }

        public override string GetCode()
        {
            return $@"
using System;
using System.Collections.Generic;

namespace {Setting.GetNamespaceDto(NameTable)}
{'{'}
    public class {Setting.GetClassDto(NameTable)}
    {'{'}
        {GetFied()}
    {'}'}
{'}'}
";
        }

        private string GetFied()
        {
            string s = "";
            foreach (var item in LstInfoTable)
            {
                s += $@"
public {item.GetTypeCs()} {item.Name.Replace(' ', '_')} {'{'} get; set; {'}'}";
            }
            foreach (var item in Table.lstFK)
            {
                var tblJoin = new TableObject(item.NameTableJoin, Connection);
                string sDto = Setting.GetClassDto(tblJoin.Name);
                s += $@"
public {sDto} {sDto}Join {'{'} get; set; {'}'}";
            }
            return s;
        }

        public override string GetNameClass()
        {
            return string.Format(Setting.Format_Basic.Format_class_DTO, NameTable);
        }

        public override string GetNameMethod(eMethod method)
        {
            throw new Exception("Class not have method - Tiệp Hoàng");
        }

        public override ResultRunCode Run()
        {
            Save(Setting.Format_Basic.FolderSave_Dto);
            return new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.Success,
                Message = $"{GetNameClass()} : Saved in {Setting.Format_Basic.FolderSave_Dto}"
            };
        }
    }
}
