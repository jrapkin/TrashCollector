using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		//public async Task<IActionResult> Index()
		//{
		//	var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
		//	//find if customer exists
		//	if (_context.Customers.Where(c => c.IdentityUserId == userId).Any())
		//	{
		//		//add customer view
		//		CustomerViewModel customerViewModel = new CustomerViewModel();
		//		var currentUser = _context.Customers.Find(userId);

		//		return View(customerViewModel);
		//	}
		//	else
		//	{
		//		return RedirectToAction("Create");
		//	}
		
		//}
		//public IActionResult Create()
		//{
		//	ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
		//	return View();
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Address, IdentityUserId")] Customer customer)
		//{
		//	if (ModelState.IsValid)
		//	{

		//		Customer customerToBeCreated = new Customer()
		//		{
		//			FirstName = customer.FirstName,
		//			LastName = customer.LastName,
		//			IdentityUserId = customer.IdentityUserId

		//		}
		//	}
		//}
	}
}
