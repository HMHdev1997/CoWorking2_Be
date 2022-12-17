﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz
{
    public interface IRepositoryWapper
    {
        Customer.IRepository Customer { get; }
        User.IRepository User { get; }
        CategoryOffice.IRepository CategoryOffice { get; }
        CategoryService.IRepository CategoryService { get; }
        CategorySpace.IRepository CategorySpace { get; }
        Area.IRepository Area { get; }
        Office.IRepository Office { get; }

    }
}