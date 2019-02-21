using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class SampleController : Controller
    {
        public ActionResult Index(int bar, string snow)
        {
           // string foo = (string) cmd.ExecuteScalar();

            SampleViewModel vm = new SampleViewModel();
            vm.Foo = bar;
            vm.Snow = snow;
            return View(vm);
        }

        public ActionResult ShowForm()
        {
            return View();
        }

        public ActionResult Search(string searchText)
        {
            SearchViewModel vm = new SearchViewModel();
            vm.SearchText = searchText;
            return View(vm);
        }
    }
}

//Create an application that has two pages:
// /northwind/categories
// /northwind/products

//On the categories page, display a list of all categories in the northwind database
//(id, name, description). The name of the category should be a link, that when clicked
//takes the user to the products page. On the products page, only the products
//for the category that was clicked on should be displayed. Additionally, on top of
//the products page, have an H1 that says "Products for Category {CategoryName}"


