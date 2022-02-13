using InterviewTask.Data;
using InterviewTask.Data.Entities;
using InterviewTask.Data.Repositories;
using InterviewTask.Helpers;
using InterviewTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTask.Controllers
{
    
    public class CartController : Controller
    {

        private readonly ICartRepositoty _repository;

        public CartController(ICartRepositoty repository)
        {
            this._repository = repository;
        }


        public IActionResult Index()
        {
            

            var cartItems = _repository.GetAllCartItems().ToList();

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems
               
            };
            // Return the view
            return View(viewModel);

        }

        //[Route("add/{id}")]
        [HttpPost]
        public IActionResult Add(int id)
        {
            Item item = new Item()

            {
                ProductId = id,
            };

            _repository.AddItemToCart(item);

            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult remove(int id)
        {
            List<Item> cartItems = _repository.GetAllCartItems().ToList();
                Item item = cartItems.FirstOrDefault(c =>c.ProductId == id);

            // Remove from cart
            int itemCount = _repository.RemoveItemFromCart(item);

            return RedirectToAction("Index");

        }

       
    }
}
