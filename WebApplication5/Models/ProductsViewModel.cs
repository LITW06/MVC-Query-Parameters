using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CategoryName { get; set; }
    }
}