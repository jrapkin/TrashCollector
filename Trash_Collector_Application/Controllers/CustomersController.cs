using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Trash_Collector_Application.Data;
using Trash_Collector_Application.Models;

namespace Trash_Collector_Application.Controllers
{
	public class CustomersController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CustomersController (ApplicationDbContext context)
		{
			_context = context;
		}

		//GET: Customers

		public async Task<IActionResult> Index()
		{
			var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
			//find if customer exists
			if (_context.Customers.Where(c => c.IdtentityUserId == userId).Any())
			{
				//add customer view
				CustomerViewModel customerViewModel = new CustomerViewModel();

				return View(customerViewModel);
			}
			else
			{
				return RedirectToAction("Create");
			}
		}
	}
}
