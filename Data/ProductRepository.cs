using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSVerticalSlices.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSVerticalSlices.Data
{
    public class ProductRepository : IProductRepository
    {
        public DataContext _context { get; }
        public ProductRepository(DataContext context) => _context = context;
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}