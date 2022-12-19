using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model
{
    public class CoException : Exception
    {
        public CoException()
        {

        }
        public CoException(string message) : base(message)
        {

        }
        public CoException(string message, Exception inner): base(message, inner)
        {

        }

    }
}
