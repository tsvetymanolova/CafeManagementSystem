using CafeManagementSystemProject.Models;
using CafeManagementSystemProject.Repositories.Interfaces;
using CafeManagementSystemProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystemProject.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            orderRepository.AddOrder(order);
        }

        public List<Order> GetAll()
           => orderRepository.GetAll();


        public Order GetById(int table_id)
        => orderRepository.GetById(table_id);
        public void AddProductToOrder(Product product)
        {
            orderRepository.AddProductToOrder(product);
        }
        public void RemoveProductFromOrder(Product product)
        {
            orderRepository.RemoveProductFromOrder(product);
        }

        public string CheckOut()
        {
            int table_id = int.Parse(Console.ReadLine());
            int order_id = int.Parse(Console.ReadLine());
            int quantity = int.Parse(Console.ReadLine());
            List<Order> orders = new List<Order>();
            List<OrdersProducts> ordersProducts = new List<OrdersProducts>();
            List<Product> products = new List<Product>();
            double sumOfProductPrices = products.Sum(product => product.Price) * quantity;
            string order = $"Reciept of Table№{table_id}"
            + Environment.NewLine
            + $"Order №{order_id}"
            + Environment.NewLine
            + $"Total Price: {sumOfProductPrices:F2}"
            + Environment.NewLine
            + $"Products:";
            foreach (var product in products)
            {
                order += Environment.NewLine + product.ToString();
            }
            return order;

        }
    }
}