using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public DateTime Date { get; set; }
    }
}