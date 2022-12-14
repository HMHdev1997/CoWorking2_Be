using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Common
{
    public class Response
    {
        public static ResultModel Error(int code, string message)
        {
            return new ResultModel(SystemParam.ERROR, code, message, "");
        }
    }
}
