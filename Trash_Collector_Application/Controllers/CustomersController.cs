using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

		public IActionResult Index()
		{
			var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
			//find if customer exists
			if (_context.Customers.Where(c => c.IdentityUserId == userId).Any())
			{
				//add customer view
				CustomerViewModel customerViewModel = new CustomerViewModel();
				var currentUser = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
				customerViewModel.Customer = currentUser;
				customerViewModel.Address = currentUser.Address;
				return View(customerViewModel);
			}
			else
			{
				return RedirectToAction("Create");
			}
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id, FirstName, LastName, Address, IdentityUserId")] Customer customer, Account account)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Address newAddress = new Address()
					{
						StreetAddress = customer.Address.StreetAddress,
						City = customer.Address.City,
						State = customer.Address.State,
						ZipCode = customer.Address.ZipCode
					};
					_context.Addresses.Add(newAddress);
					_context.SaveChanges();
					Customer customerToBeCreated = new Customer()
					{
						FirstName = customer.FirstName,
						LastName = customer.LastName,
						IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
						AddressId = newAddress.Id
					};
					_context.Customers.Add(customerToBeCreated);
					_context.SaveChanges();
					return RedirectToAction(nameof(Index));
				}
				catch
				{
					return View();
				}
			}
			else
			{
				//if we got this far something went wrong
				return View();
			}
		}
		//TODO Build out createaccount post method
		public IActionResult CreateAccount()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateAccount(Account account, Service service)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Service newService = new Service()
					{
						DayOfService = service.DayOfService,
						NextServiceDay = service.NextServiceDay.AddDays(7),
						IsOnHold = service.IsOnHold,
						OneTimeService = service.OneTimeService,
						StartServiceHold = service.StartServiceHold,
						EndServiceHold = service.EndServiceHold
					};
					_context.Services.Add(newService);
					_context.SaveChanges();
					Account newAccount = new Account()
					{
						ServiceId = newService.Id,
						AccountBalance = 0,
					};
					_context.Accounts.Add(newAccount);
					_context.SaveChanges();
					var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
					var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
					customer.AccountId = newAccount.Id;
					_context.Customers.Update(customer);
					_context.SaveChanges();
					return RedirectToAction(nameof(Index));
				}
				catch
				{
					return View();
				}
			}
			else
			{
				return View();
			}
		}
	}
}
