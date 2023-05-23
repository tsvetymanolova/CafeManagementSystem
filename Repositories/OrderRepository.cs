using CafeManagementSystemProject.DataFolder;
using CafeManagementSystemProject.Models;
using CafeManagementSystemProject.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CafeManagementSystemProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private MVCOrderDbContext context;
        public OrderRepository(MVCOrderDbContext context)
        {
            this.context = context;
        }
        public void AddOrder(Order order)
        {
            context.Add(order);
            context.SaveChanges();
        }

        public List<Order> GetAll()
            => context.Order.ToList();
        public Order GetById(int table_id)
        => context.Order.FirstOrDefault(o => o.TableId == table_id);

        public void AddProductToOrder(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }
        public void RemoveProductFromOrder(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }

        public string CheckOut()
        {
            context.Find<Order>();
            context.Find<Product>();
            context.Find<OrdersProducts>();
            context.Add(new List<Product>());
            context.SaveChanges();
            return CheckOut();
        }
    }
}
