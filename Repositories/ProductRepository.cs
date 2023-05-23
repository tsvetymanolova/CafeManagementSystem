using CafeManagementSystemProject.DataFolder;
using CafeManagementSystemProject.Models;
using CafeManagementSystemProject.Repositories.Interfaces;

namespace CafeManagementSystemProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private MVCOrderDbContext context;

        public ProductRepository(MVCOrderDbContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
            => context.Products.ToList();

        public Product GetById(int product_id)
            => context.Products.FirstOrDefault(p => p.ProductId == product_id);

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            context.Products.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
