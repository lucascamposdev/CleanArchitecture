using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int id);
        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Delete(Product category);

        Task<Product> GetProductCategory(int id);
    }
}
