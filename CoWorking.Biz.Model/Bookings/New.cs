﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Bookings
{
    public class New
    {
        public int ID { set; get; }
        public int UserId { set; get; }
        public int OfficeId { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public double Total { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
