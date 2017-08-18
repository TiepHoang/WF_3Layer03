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
        public Bus(string nameTable, SqlConnection connection, Setting setting) : base(nameTable, connection, setting)
        {

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
    public class {5}{6}
    {'{'}
        {Get_GetAll()}
        {Get_GetBy()}
        {Get_Insert()}
        {Get_Delete()}
        {Get_DeleteBy()}
        {Get_Update()}
    {'}'}
{'}'}
";
        }

        private object Get_GetAll()
        {
            throw new NotImplementedException();
        }

        private object Get_GetBy()
        {
            throw new NotImplementedException();
        }

        private object Get_Insert()
        {
            throw new NotImplementedException();
        }

        private object Get_Delete()
        {
            throw new NotImplementedException();
        }

        private object Get_DeleteBy()
        {
            throw new NotImplementedException();
        }

        private object Get_Update()
        {
            throw new NotImplementedException();
        }

        public override string GetNameClass()
        {
            return string.Format(Setting.Format_Basic.Format_class_BUS, NameTable);
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
