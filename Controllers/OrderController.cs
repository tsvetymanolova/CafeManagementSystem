using CafeManagementSystemProject.Models;
using CafeManagementSystemProject.Services.Interfaces;
using CafeManagementSystemProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystemProject.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IProductService productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult Index()
        {
            var orders = orderService.GetAll();
            return View(orders);
        }
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            orderService.AddOrder(order);

            return RedirectToAction(nameof(AddProductToOrder));
        }

        public IActionResult AddProductToOrder(int product_id)
        {
            var product = productService.GetById(product_id);

            return View(product);
        }
        [HttpPost]
        public IActionResult AddProductToOrder(Product product)
        {
            orderService.AddProductToOrder(product);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveProductFromOrder(int product_id)
        {
            var product = productService.GetById(product_id);

            return View(product);
        }
        [HttpPost]
        public IActionResult RemoveProductFromOrder(Product product)
        {
            orderService.RemoveProductFromOrder(product);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CheckOut()
        {
            orderService.CheckOut();
            return RedirectToAction(nameof(Index));
        }
    }
}