using CafeManagementSystemProject.Models;
using CafeManagementSystemProject.DataFolder;
using CafeManagementSystemProject.Services.Interfaces;
using CafeManagementSystemProject.Repositories.Interfaces;

namespace CafeManagementSystemProject.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public List<Product> GetAll()
        => productRepository.GetAll();

        public Product GetById(int iproduct_id)
            => productRepository.GetById(iproduct_id);

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }


        public void EditProduct(Product product)
        {
            productRepository.EditProduct(product);
        }

        public void DeleteProduct(int product_id)
        {
            productRepository.DeleteProduct(product_id);
        }
    }
}