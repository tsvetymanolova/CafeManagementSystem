using CafeManagementSystemProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystemProject.Services.Interfaces
{
    public interface IOrderService
    {
        public void AddOrder(Order order);
        List<Order> GetAll();
        Order GetById(int table_id);
        public void AddProductToOrder(Product product);
        public void RemoveProductFromOrder(Product product);

        public string CheckOut();
    }
}
