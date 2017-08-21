using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ResultRunCode
    {
        public enum eStatus
        {
            NotRun,
            Success,
            Error
        }

        public eStatus Status { get; set; }
        public string Message { get; set; }

        public ResultRunCode()
        {
            Status = eStatus.NotRun;
            Message = "";
        }

        public override string ToString()
        {
            return Status.ToString() + " " + Message.ToString();
        }
    }
}
