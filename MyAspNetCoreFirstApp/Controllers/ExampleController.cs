using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetCoreFirstApp.Controllers
{
    public class ProductList
    {
        public int productId { get; set; }
        public string productName { get; set; }

    }
    public class ExampleController : Controller
    {
    
        // GET: /<controller>/
        //baseURL/example/index
        public IActionResult Index()
        {
            ViewBag.name = "Rumeysa Betül Kayrak";

            ViewData["age"] = 24;

            ViewData["Courses"] = new List<string> { "Math", "Comp", "algebra" };

            ViewBag.person = new { Id = 1, Name = "Rbk", Age = 24 };
            TempData["surname"] = "Kyrk";

            var productList = new List<ProductList>()
            {
                new () {productId=1,productName="paper"},
                new ProductList() {productId=2, productName="pencil"},
                new ProductList() {productId=3, productName="book"}

            };

            return View(productList);
        }

        public IActionResult IndexOfTempData()
        {
            //debug koyup kontrol ettiğinizde başka bir action view içinden tempdata ile veri çekebiliyoruz
            //var surname = TempData["surname"];

            return View();

        }
        //baseURL/example/ContentResult
        public IActionResult ContentResult()
        {
            return Content("Content Result");
        }

        //baseURL/example/JsonResult
        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, itemName = "mouse", price = 200 });
        }

        //baseURL/example/EmptyResult
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }

        public IActionResult Index2()
        {
            //baseUrL/example/index2 sayfası açıldığında direkt olarak /home/privacy yönlendiriliyor.
            //eğer bu controller içinde yönlendirirsem ("Index") ya da ("Index", "Example") şeklindedir.
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JustId", "Example", new { id = id });
        }

        public IActionResult JustId(int id)
        {
            return Json(new { Id = id });
        }
    }
}

