using InterviewTask.Data;
using InterviewTask.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InterviewTask.Controllers
{
	public class ProductController : Controller
	{
  
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }


		// TODO: map this to `product/id`, the expected full url `https://localhost:44340/product/id`
		public IActionResult ViewProduct(int id)
		{
			var product = _repository.GetProductById(id);
			return View(product);
		}

		// TODO: map this to `product-list`, the expected full url `https://localhost:44340/product-list`
		public IActionResult ProductsList()
		{
			var products =  _repository.GetAllProducts();
			return View(products);
		}
	}
}
