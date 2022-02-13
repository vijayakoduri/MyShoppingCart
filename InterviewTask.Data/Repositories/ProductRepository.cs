using InterviewTask.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SampleDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductRepository(SampleDbContext dbContext, ILogger<ProductRepository> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        /// <summary>
        /// Get all the products from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = new List<Product>();

            try
            {


                products = _dbContext.Product.ToList();

                if (products.Any())
                {
                    foreach (var prod in products)
                    {
                        List<ProductGallery> ProductGalleries = new List<ProductGallery>();
                        ProductGalleries = GetProductGalleries(prod.Id).ToList();

                        if (ProductGalleries.Any())
                            prod.ProductGalleries = ProductGalleries.ToList();
                    }

                    _logger.LogInformation("Number of products returned is : {0}", products.Count());
                }
            }
            catch (Exception ex)
            {

                // Catch the exception and log it
                _logger.LogError("An error has occured in the GetAllProducts ", ex.InnerException);
            }



            return products;
        }

        /// <summary>
        /// Get product information by product Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product GetProductById(int Id)
        {
            Product prod = new Product();
            try
            {


                 prod = _dbContext.Product
                    .Where(x => x.Id == Id)
                    .FirstOrDefault();

                if (prod != null)
                {
                    prod.ProductGalleries = GetProductGalleries(prod.Id).ToList();
                }
            }
            catch (Exception ex)
            {

                // Catch the exception and log it
                _logger.LogError("An error has occured in the GetProductById ", ex.InnerException);
            }

            return prod;
        }

        /// <summary>
        /// Populate the product galleries information for the products by Product Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private IEnumerable<ProductGallery> GetProductGalleries(int Id)
        {
            List<ProductGallery> ProductGalleries  = new List<ProductGallery>();
            try
            {


                ProductGalleries = new List<ProductGallery>();
                ProductGalleries = _dbContext.ProductGalleries.ToList();

                if (ProductGalleries.Any())
                    ProductGalleries = ProductGalleries.Where(x => x.ProductiD == Id).ToList();


            }
            catch (Exception ex)
            {

                // Catch the exception and log it
                _logger.LogError("An error has occured in the GetProductGalleries ", ex.InnerException);
            }
            return ProductGalleries;
        }
    }
}
