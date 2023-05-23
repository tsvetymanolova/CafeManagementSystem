using CafeManagementSystemProject.DataFolder;
using CafeManagementSystemProject.Models;

namespace CafeManagementSystemProject.Repositories.Interfaces
{
    public interface IProductRepository
    {
            List<Product> GetAll();
        Product GetById(int product_id);

        public void AddProduct(Product product);

        public void EditProduct(Product product);

        public void DeleteProduct(int product_id);
    }
}
