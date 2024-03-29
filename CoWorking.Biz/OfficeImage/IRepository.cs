﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.OfficeImage
{
    public interface IRepository
    {
        Task<Model.OfficeImages.View> CreateAsync(Model.OfficeImages.New model);
        Task<Model.OfficeImages.View> GetById(int id);
    }
}
