using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreFirstApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetCoreFirstApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        private readonly ProductRepository _productRepository;

        public ProductController()
        {
             _productRepository= new ProductRepository();

            //data yoksa any kontrolünde false döner, ardından ! ile if içeriği çalışır.
            //if (!_productRepository.GetAll().Any())
            //{
            //    _productRepository.Add(new() { Id = 0, ProductName = "paper", Price = 10, Stock = 3 });
            //    _productRepository.Add(new() { Id = 1, ProductName = "keyboard", Price = 60, Stock = 6 });
            //    _productRepository.Add(new() { Id = 2, ProductName = "book", Price = 50, Stock = 7 });
            //}
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();


            return View(products);
        }

        public IActionResult Remove(int id)
        {
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }


    }
}

