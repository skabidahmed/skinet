using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<ProductBrand>> GetAllProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p =>p.ProductBrand)
                .Include(p =>p.ProductType)
                .ToListAsync();
        }

        public async Task<List<ProductType>> GetAllProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            return await _context.Products
                .Include(p =>p.ProductBrand)
                .Include(p =>p.ProductType)
                .FirstOrDefaultAsync(i =>i.Id==id);
        }
    }
}