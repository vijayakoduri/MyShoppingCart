using InterviewTask.Data.Entities;
using System.Collections.Generic;

namespace InterviewTask.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int Id);
    }
}