using InterviewTask.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Data.Repositories
{
    public class CartRepositoty : ICartRepositoty
    {
        private readonly SampleDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;

        public CartRepositoty(SampleDbContext dbContext, ILogger<CartRepositoty> logger, IProductRepository productRepository)
        {
            this._dbContext = dbContext;
            this._logger = logger;
            this._productRepository = productRepository;
        }

        void ICartRepositoty.AddItemToCart(Item item)
        {
            try
            {

           
            // Get the matching cart and product instances
            var cartItem = _dbContext.Items.SingleOrDefault(
                i => i.ProductId == item.ProductId);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Item
                {
                    ProductId = item.ProductId,
                    quantity   = 1
                };

                _dbContext.Items.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.quantity++;
            }

            // Save changes
            _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                // Catch the exception and log it
                _logger.LogError("An error has occured in the AddItemToCart ", ex.InnerException);
            }

        }

        IEnumerable<Item> ICartRepositoty.GetAllCartItems()
        {
            try
            {



                IEnumerable<Item> items = _dbContext.Items.ToList();
                foreach (var item in items)
                {
                    item.Product = _productRepository.GetProductById(item.ProductId);
                }


            }
            catch (Exception ex)
            {

                // Catch the exception and log it
                _logger.LogError("An error has occured in the GetAllCartItems ", ex.InnerException);
            }

            return _dbContext.Items.ToList();
        }

        int ICartRepositoty.RemoveItemFromCart(Item item)
        {
            int itemCount = 0;
            try
            {




                // Check if the item exsists in the database
                var cartItem = _dbContext.Items.SingleOrDefault(
                    i => i.Id == item.Id
                    && i.ProductId == item.ProductId);

                if (cartItem != null)
                {

                    if (cartItem.quantity > 1)
                    {
                        cartItem.quantity--;
                        itemCount = cartItem.quantity;
                    }
                    else
                    {
                        _dbContext.Items.Remove(cartItem);
                    }


                    // Save changes
                    _dbContext.SaveChanges();
                }


            }
            catch (Exception ex)
            {

                // Catch the exception and log it
                _logger.LogError("An error has occured in the RemoveItemFromCart ", ex.InnerException);
            }
            return itemCount;
        }
    }
}

