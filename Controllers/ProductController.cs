﻿using CafeManagementSystemProject.Models;
using CafeManagementSystemProject.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystemProject.Controllers
{
    public class ProductController : Controller
    {

        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = productService.GetAll();

            return View(products);
        }

        public IActionResult CreateProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            productService.AddProduct(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProduct(int product_id)
        {
            var product = productService.GetById(product_id);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            productService.EditProduct(product);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = productService.GetById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProductConfirm(int id)
        {
            productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}