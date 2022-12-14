using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Common
{
    public  class ResultModel
    {
        public int Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResultModel(int status, int code, string message, object data)
        {
            this.Status = status;
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
    }
}
