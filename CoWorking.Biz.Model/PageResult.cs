using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model
{
    public class PageResult<T> : PagingRequestBase
    {
        public List<T> Item { set; get; }
    }
}
