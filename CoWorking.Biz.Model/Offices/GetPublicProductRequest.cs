using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Offices
{
    public class GetPublicProductRequest : PagingRequestBase
    {
        public int? AreaId { set; get; }
        

    }
}
