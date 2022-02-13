using InterviewTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Data
{
    public  class ProductSeeder
    {
        private readonly SampleDbContext _Context;
        public ProductSeeder(SampleDbContext context)
        {
            _Context = context;
        }

        public void seed()
        {
            _Context.Database.EnsureCreated();

            if (!_Context.Product.Any())
            {
                // Need to create sample data
                List<Product> products = new List<Product>();
                products.Add(new Product
                {
                    //Id = 1,
                    Description = "Apple airpods pro white",
                    Title = "Apple Airpods"

                });
                products.Add(
                new Product
                {
                    //Id = 2,
                    Description = "Apple watch series 6",
                    Title = "Apple Watch"

                });

                _Context.Product.AddRange(products);


                // Need to create sample data
                List<ProductGallery> ProductGalleries = new List<ProductGallery>();
                ProductGalleries.Add(new ProductGallery
                {
                    //Id = 1,
                    ProductiD = 7,
                    Name = "Apple airpods white 1",
                    Url = "~/content/product-images/apple-airpods-pro-white-6302072_00.webp"

                });
                ProductGalleries.Add(
                new ProductGallery
                {
                    //Id = 2,
                    ProductiD = 7,
                    Name = "Apple airpods white 2",
                    Url = "~/content/product-images/apple-airpods-pro-white-6302072_01.webp"

                });

                ProductGalleries.Add(
               new ProductGallery
               {
                   //Id = 3,
                   ProductiD = 8,
                   Name = "Apple watch red 1",
                   Url = "~/content/product-images/apple-watch-series-6-gps-40mm-with-red-aluminium-case-red-sport-band-6728098_00.webp"

               });

                ProductGalleries.Add(
               new ProductGallery
               {
                   //Id = 4,
                   ProductiD = 8,
                   Name = "Apple watch red 2",
                   Url = "~content/product-images/apple-watch-series-6-gps-40mm-with-red-aluminium-case-red-sport-band-6728098_05.webp"

               });

                _Context.ProductGalleries.AddRange(ProductGalleries);

                _Context.SaveChanges();

            }
        }
    }
}
