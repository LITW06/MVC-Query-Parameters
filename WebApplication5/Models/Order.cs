using System;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
    }
}