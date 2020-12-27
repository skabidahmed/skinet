using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<List<Product>> GetAllProductsAsync();
         Task<Product> GetProductByIDAsync(int id);
         Task<List<ProductBrand>> GetAllProductBrandsAsync();
         Task<List<ProductType>> GetAllProductTypesAsync();
    }
}