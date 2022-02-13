using InterviewTask.Data.Entities;
using InterviewTask.Data.Repositories;
using InterviewTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTask.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IProductRepository _repository;

		public HomeController(ILogger<HomeController> logger, IProductRepository repository)
		{
			_logger = logger;
			this._repository = repository;
		}


		public IActionResult Index()
        {
            int? id = null;
            List<Product> products = null;
			products = _repository.GetAllProducts().ToList();
			if (products != null)
				id = products[0].Id;
			ViewBag.Id = id;

            return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}
