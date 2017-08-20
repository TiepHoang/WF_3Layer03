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
            var lsKey = LstInfoTable.Where(q => q.isKey).ToList();
            if (lsKey.Count < 2) return "";
            var lsName = GetName(eMethod.GetBy);
            string r = "";
            for (int i = 0; i < lsKey.Count; i++)
            {
                string len = string.IsNullOrWhiteSpace(lsKey[i].Length) ? "" : $"({lsKey[i].Length})";
                string param = $"@{lsKey[i].Name} {lsKey[i].Type}{len}";
                string rs = $@"
;CREATE PROC {lsName[i]}
{param}
AS BEGIN
    SELECT * FROM [{Table}] WHERE [{lsKey[i].Name}] = @{lsKey[i].Name}
END;
";
                Map.Add(GetName(eMethod.GetBy)[i], rs);
                r += rs;
            }
            return r;
        }

        private string GetDelete()
        {
            var lsKey = LstInfoTable.Where(q => q.isKey).ToList();
            if (lsKey.Count < 1) return "";
            string param = "";
            string where = "";
            string s = "";
            string len = "";
            foreach (var item in lsKey)
            {
                len = string.IsNullOrWhiteSpace(item.Length) ? "" : $"({item.Length})";
                s = string.IsNullOrWhiteSpace(param) ? " " : " , ";
                param += $"{s} @{item.Name} {item.Type}{len}";

                s = string.IsNullOrWhiteSpace(where) ? " " : "AND";
                where += $" {s} [{item.Name}] = @{item.Name} ";

            }
            string r = $@"
;CREATE PROC {GetName(eMethod.Delete)[0]}
{param}
AS BEGIN
    DELETE [{Table}] WHERE {where}
END;
";
            Map.Add(GetName(eMethod.Delete)[0], r);
            return r;
        }

        private string GetUpdate()
        {
            var lsKey = LstInfoTable.Where(q => q.isKey).ToList();
            if (lsKey.Count < 1) return "";
            string param = "";
            string value = "";
            string where = "";
            string s = "";
            string len = "";
            foreach (var item in LstInfoTable)
            {
                len = string.IsNullOrWhiteSpace(item.Length) ? "" : $"({item.Length})";

                s = string.IsNullOrWhiteSpace(param) ? "" : ",";
                param += $"{s} @{item.Name} {item.Type}{len}";

                if (item.isKey)
                {
                    s = string.IsNullOrWhiteSpace(where) ? "" : " AND ";
                    where += $" {s} [{item.Name}] = @{item.Name}";
                }
                else
                {
                    s = string.IsNullOrWhiteSpace(value) ? "" : ",";
                    value += $"{s} [{item.Name}] = @{item.Name}";
                }
            }
            string r = $@"
;CREATE PROC {GetName(eMethod.Update)[0]}
{param}
AS BEGIN
    UPDATE [{Table}] SET {value} WHERE {where}
END;
";
            Map.Add(GetName(eMethod.Update)[0], r);
            return r;
        }

        private string GetInsert()
        {
            var lsKey = LstInfoTable.Where(q => q.isKey).ToList();
            if (lsKey.Count < 1) return "";
            string param = "";
            string value = "";
            string column = "";
            string s = "";
            string len = "";
            foreach (var item in LstInfoTable)
            {
                if (!item.isIdentity)
                {
                    len = string.IsNullOrWhiteSpace(item.Length) ? "" : $"({item.Length})";
                    s = string.IsNullOrWhiteSpace(param) ? "" : ",";
                    param += $"{s} @{item.Name} {item.Type}{len}";

                    s = string.IsNullOrWhiteSpace(value) ? "" : ",";
                    value += $"{s} @{item.Name}";

                    s = string.IsNullOrWhiteSpace(column) ? "" : ",";
                    column += $" {s} [{item.Name}]";
                }
            }
            string r = $@"
;CREATE PROC {GetName(eMethod.Insert)[0]}
{param}
AS BEGIN
    INSERT INTO [{Table}]({column}) VALUES({value})
END;
";
            Map.Add(GetName(eMethod.Insert)[0], r);
            return r;
        }

        private string GetAll()
        {
            string r = $@"
;CREATE PROC {GetName(eMethod.GetAll)[0]}
AS BEGIN
    SELECT * FROM [{Table}]
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
                MessageError = ""
            };
            foreach (var item in Map)
            {
                try
                {
                    new SqlProvider().ExecuteQuery(item.Value, Connection);
                }
                catch (Exception ex)
                {
                    r.Status = ResultRunCode.eStatus.Error;
                    r.MessageError += $@"
{item.Key} : {ex.Message}";
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
                    var ls = LstInfoTable.Where(q => q.isKey).ToList();
                    if (ls.Count > 1)
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
