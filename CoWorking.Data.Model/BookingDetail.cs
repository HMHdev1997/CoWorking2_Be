﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("BookingDetail")]
    public class BookingDetail
    {   
        [Key]
        public int ID { set; get; }
        [ForeignKey("BookingId")]
        public int BookingId { set; get; }
        public string Name { set; get; }
        public int Number { set; get; }
        public double Price { set; get; }
        public string Note { set; get; }
        public DateTime? StartTime { set; get; }
        public DateTime? EndTime { set; get; }
        public int PaymentStatus { set; get; }
        public DateTime? CreaetDate { set; get; }
        public string CreateBy { set; get; }
        public virtual Booking Booking { set; get; }
    }
}