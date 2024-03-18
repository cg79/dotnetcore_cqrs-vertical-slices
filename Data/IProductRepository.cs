using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSVerticalSlices.Models;

namespace CQRSVerticalSlices.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
    }
}