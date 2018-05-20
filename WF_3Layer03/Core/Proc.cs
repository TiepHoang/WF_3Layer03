using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Proc : Bussiness
    {
        public Dictionary<string, string> Map { get; protected set; }

        public Proc(string nameTable, SqlConnection connection, Setting setting) : base(nameTable, connection, setting)
        {
            Map = new Dictionary<string, string>();
            GetCode();
        }

        public override string GetCode()
        {
            Map = new Dictionary<string, string>();
            return $@"
{GetAll()}
{GetInsert()}
{GetUpdate()}
{GetDelete()}
{GetBy()}
";
        }

        //        private string GetDeleteBy()
        //        {
        //            var lsKey = LstInfoTable.Where(q => q.isKey).ToList();
        //            if (lsKey.Count < 2) return "";
        //            var lsName = GetName(eMethod.DeleteBy);
        //            string r = "";
        //            for (int i = 0; i < lsKey.Count; i++)
        //            {
        //                string len = string.IsNullOrWhiteSpace(lsKey[i].Length) ? "" : $"({lsKey[i].Length})";
        //                string param = $"@{lsKey[i].Name} {lsKey[i].Type}{len}";
        //                string rs = $@"
        //;CREATE PROC {lsName[i]}
        //{param}
        //AS BEGIN
        //    DELETE {Table} WHERE {lsKey[i].Name} = @{lsKey[i].Name}
        //END;
        //";
        //                Map.Add(GetName(eMethod.DeleteBy)[0], rs);
        //                r += rs;
        //            }
        //            return r;
        //        }

        private string GetBy()
        {
            var lsKey = LstInfoTable.Where(q => q.IsPK).ToList();
            if (lsKey.Count < 1) return "";
            var lsName = GetName(eMethod.GetBy);
            string r = "";
            for (int i = 0; i < lsKey.Count; i++)
            {
                string len = string.IsNullOrWhiteSpace(lsKey[i].Length) ? "" : $"({lsKey[i].Length})";
                string param = $"@{lsKey[i].Name.Replace(' ', '_')} {lsKey[i].Type}{len}";
                string col = "";
                string join = "";
                string where = $" WHERE [{NameTable}].[{lsKey[i].Name}] = @{lsKey[i].Name.Replace(' ', '_')} ";
                //columns select
                foreach (var item in Table.lstColumns)
                {
                    if (item.Type.Equals("bit") && item.Name.ToLower().Contains("delete"))
                    {
                        where += $" AND [{NameTable}].[{item.Name}] <> 1 ";
                    }
                    string s = string.IsNullOrWhiteSpace(col) ? "" : ",";
                    if (item.Name.Any(c => c == ' '))
                    {
                        col += $@"
{s}[{NameTable}].[{item.Name}] as [{item.Name.Replace(' ', '_')}]";
                    }
                    else
                    {
                        col += $@"
{s}[{NameTable}].[{item.Name}]";
                    }
                }
                //column join
                foreach (var item in Table.lstFK)
                {
                    var tblJoin = new TableObject(item.NameTableJoin, Connection);
                    string sTbl = Setting.GetNameTable(tblJoin.Name) + "Join";
                    foreach (var co in tblJoin.lstColumns)
                    {
                        if (co.IsPK) continue;
                        col += $@"
,[{sTbl}].[{co.Name}] as [{co.Name.Replace(' ', '_')}_{sTbl}]";
                    }
                    join += $@"
join [{tblJoin.Name}] as [{sTbl}] on [{NameTable}].[{item.Name}] = [{sTbl}].[{tblJoin.lstColumns.First(q => q.IsPK).Name}]";
                }
                string rs = $@"
;CREATE PROC {lsName[i]}
{param}
AS BEGIN
    SELECT 
    {col} 
    FROM [{sTable}] as [{NameTable}] 
    {join} 
    {where}
END;
";
                Map.Add(GetName(eMethod.GetBy)[i], rs);
                r += rs;
            }
            return r;
        }

        private string GetDelete()
        {
            var lsKey = LstInfoTable.Where(q => q.IsPK).ToList();
            if (lsKey.Count < 1) return "";
            string param = "";
            string where = "";
            string s = "";
            string len = "";
            string r = "";
            foreach (var item in lsKey)
            {
                len = string.IsNullOrWhiteSpace(item.Length) ? "" : $"({item.Length})";
                s = string.IsNullOrWhiteSpace(param) ? " " : " , ";
                param += $"{s} @{item.Name.Replace(' ', '_')} {item.Type}{len}";

                s = string.IsNullOrWhiteSpace(where) ? " " : "AND";
                where += $" {s} [{item.Name}] = @{item.Name.Replace(' ', '_')} ";

            }

            //delete if table have column "delete"
            var cDelete = LstInfoTable.FirstOrDefault(q => q.Type.ToLower().Equals("bit") && q.Name.ToLower().Contains("delete"));
            if (cDelete != null)
            {
                r = $@"
;CREATE PROC {GetName(eMethod.Delete)[0]}
{param}
AS BEGIN
    UPDATE [{sTable}] SET [{cDelete.Name}] = 1 WHERE {where}
END;";
            }
            else
            {
                r = $@"
;CREATE PROC {GetName(eMethod.Delete)[0]}
{param}
AS BEGIN
    DELETE [{sTable}] WHERE {where}
END;
";
            }
            Map.Add(GetName(eMethod.Delete)[0], r);
            return r;
        }

        private string GetUpdate()
        {
            var lsKey = LstInfoTable.Where(q => q.IsPK).ToList();
            if (lsKey.Count < 1 || LstInfoTable.Count == lsKey.Count) return "";
            string param = "";
            string value = "";
            string where = "";
            string s = "";
            string len = "";
            foreach (var item in LstInfoTable)
            {
                len = string.IsNullOrWhiteSpace(item.Length) ? "" : $"({item.Length})";

                s = string.IsNullOrWhiteSpace(param) ? "" : ",";
                param += $"{s} @{item.Name.Replace(' ', '_')} {item.Type}{len}";

                if (item.IsPK)
                {
                    s = string.IsNullOrWhiteSpace(where) ? "" : " AND ";
                    where += $" {s} [{item.Name}] = @{item.Name}";
                }
                else
                {
                    s = string.IsNullOrWhiteSpace(value) ? "" : ",";
                    value += $"{s} [{item.Name}] = @{item.Name.Replace(' ', '_')}";
                }
            }
            string r = $@"
;CREATE PROC {GetName(eMethod.Update)[0]}
{param}
AS BEGIN
    UPDATE [{sTable}] SET {value} WHERE {where}
END;
";
            Map.Add(GetName(eMethod.Update)[0], r);
            return r;
        }

        private string GetInsert()
        {
            var lsKey = LstInfoTable.Where(q => q.IsPK).ToList();
            if (lsKey.Count < 1) return "";
            string param = "";
            string value = "";
            string column = "";
            string s = "";
            string len = "";
            foreach (var item in LstInfoTable)
            {
                if (!item.IsIdentity)
                {
                    len = string.IsNullOrWhiteSpace(item.Length) ? "" : $"({item.Length})";
                    s = string.IsNullOrWhiteSpace(param) ? "" : ",";
                    param += $"{s} @{item.Name.Replace(' ', '_')} {item.Type}{len}";

                    s = string.IsNullOrWhiteSpace(value) ? "" : ",";
                    value += $"{s} @{item.Name.Replace(' ', '_')}";

                    s = string.IsNullOrWhiteSpace(column) ? "" : ",";
                    column += $" {s} [{item.Name}]";
                }
            }
            string r = $@"
;CREATE PROC {GetName(eMethod.Insert)[0]}
{param}
AS BEGIN
    INSERT INTO [{sTable}]({column}) VALUES({value})
END;
";
            Map.Add(GetName(eMethod.Insert)[0], r);
            return r;
        }

        private string GetAll()
        {
            string col = "";
            string r = "";
            string where = "";
            string join = "";

            //columns select
            foreach (var item in Table.lstColumns)
            {
                string s = string.IsNullOrWhiteSpace(col) ? "" : ",";
                col += $@"
{s}[{NameTable}].[{item.Name}]";
            }

            //columns join
            foreach (var item in Table.lstFK)
            {
                var tblJoin = new TableObject(item.NameTableJoin, Connection);
                string sTbl = Setting.GetNameTable(tblJoin.Name) + "Join";

                foreach (var co in tblJoin.lstColumns)
                {
                    if (co.IsPK) continue;

                    col += $@"
,[{sTbl}].[{co.Name}] as [{co.Name}_{sTbl}]";

                }
                join += $@"
join [{tblJoin.Name}] as [{sTbl}] on [{NameTable}].[{item.Name}] = [{sTbl}].[{tblJoin.lstColumns.First(q => q.IsPK).Name}]";
            }

            //where
            var cDelete = LstInfoTable.FirstOrDefault(q => q.Type.ToLower().Equals("bit") && q.Name.ToLower().Contains("delete"));
            if (cDelete != null)
            {
                where += $@"
WHERE [{NameTable}].[{cDelete.Name}] <> 1 ";
            }

            r = $@"
;CREATE PROC {GetName(eMethod.GetAll)[0]}
AS BEGIN
    SELECT {col} FROM [{sTable}] as [{NameTable}] 
    {join} 
    {where}
END;
";
            Map.Add(GetName(eMethod.GetAll)[0], r);
            return r;
        }

        public override string GetNameClass()
        {
            return Setting.GetNameProc(NameTable);
        }

        public override string GetNameMethod(eMethod method)
        {
            throw new NotImplementedException();
        }

        public override ResultRunCode Run()
        {
            ResultRunCode r = new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.Success,
                Message = ""
            };
            foreach (var item in Map)
            {
                try
                {
                    new SqlProvider().ExecuteQuery(item.Value, Connection);
                    r.Message = $"{item.Key} : {r.Status.ToString()}";
                }
                catch (Exception ex)
                {
                    r.Status = ResultRunCode.eStatus.Error;
                    r.Message = $"{item.Key} : {ex.Message}";
                }
            }
            return r;
        }

        public List<string> GetName(Bussiness.eMethod method)
        {
            List<string> lst = new List<string>();
            switch (method)
            {
                case Bussiness.eMethod.GetAll:
                    lst.Add($"{Setting.GetNameProc(NameTable)}_{method.ToString()}");
                    break;
                case Bussiness.eMethod.Insert:
                    lst.Add($"{Setting.GetNameProc(NameTable)}_{method.ToString()}");
                    break;
                case Bussiness.eMethod.Delete:
                    lst.Add($"{Setting.GetNameProc(NameTable)}_{method.ToString()}");
                    break;
                case Bussiness.eMethod.Update:
                    lst.Add($"{Setting.GetNameProc(NameTable)}_{method.ToString()}");
                    break;
                case Bussiness.eMethod.GetBy:
                    var ls = LstInfoTable.Where(q => q.IsPK).ToList();
                    if (ls.Count > 0)
                    {
                        foreach (var item in ls)
                        {
                            lst.Add($"{Setting.GetNameProc(NameTable)}_{method.ToString()}{item.Name}");
                        }
                    }
                    break;
                //case Bussiness.eMethod.DeleteBy:
                //    var ls2 = LstInfoTable.Where(q => q.isKey).ToList();
                //    if (ls2.Count > 1)
                //    {
                //        foreach (var item in ls2)
                //        {
                //            lst.Add($"{Setting.GetNameProc(NameTable)}_{method.ToString()}{item.Name}");
                //        }
                //    }
                //    break;
                default:
                    break;
            }
            return lst;
        }

    }
}
