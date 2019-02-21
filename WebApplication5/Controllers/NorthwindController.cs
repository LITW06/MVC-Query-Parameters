using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult Orders()
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Order> orders = mgr.GetOrders();
            OrdersViewModel vm = new OrdersViewModel();
            vm.Orders = orders;
            vm.Date = DateTime.Now;
            return View(vm);
        }

        public ActionResult OrdersForEmployee(int employeeId)
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Order> orders = mgr.GetOrdersForEmployee(employeeId);
            OrdersViewModel vm = new OrdersViewModel();
            vm.Orders = orders;
            vm.Date = DateTime.Now;
            return View(vm);
        }

        public ActionResult OrderDetails()
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<OrderDetail> orderDetails = mgr.GetOrderDetailsFor1997();
            return View(orderDetails);
        }

        public ActionResult Categories()
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Category> categories = mgr.GetCategories();

            return View(categories);
        }

        public ActionResult Products(int categoryId)
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Product> products = mgr.GetProducts(categoryId);
            ProductsViewModel vm= new ProductsViewModel();
            vm.Products = products;
            vm.CategoryName = mgr.GetCategoryName(categoryId);

            return View(vm);
        }

        public ActionResult ShowProductSearch()
        {
            return View();
        }

        public ActionResult SearchProducts(string searchText, int minPrice)
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Product> products = mgr.SearchProducts(searchText, minPrice);
            return View(products);
        }
    }
}