using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
			if (_context.Customers.Where(c => c.IdentityUserId == userId).Any())
			{
				var currentUser = _context.Customers.Include(c => c.Address).Include(c => c.Account).ThenInclude(s => s.Service).Where(c => c.IdentityUserId == userId).FirstOrDefault();
				return View(currentUser);
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
		public IActionResult Create([Bind("Id, FirstName, LastName, Address, IdentityUserId")] Customer customer)
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
					customer.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
					customer.AddressId = newAddress.Id;
					_context.Customers.Add(customer);
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
					service.NextServiceDay = service.DayOfService;
					if(service.NextServiceDay.Equals(service.DayOfService))
					{
						service.NextServiceDay = service.NextServiceDay.AddDays(7);
					}
					_context.Services.Add(service);
					_context.SaveChanges();

					account.ServiceId = service.Id;
					account.AccountBalance ??= 0;
					_context.Accounts.Add(account);
					_context.SaveChanges();

					var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
					var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
					customer.AccountId = account.Id;
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
		public IActionResult EditService()
		{
			var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return NotFound();
			}
			var customer = _context.Customers.Include(c => c.Account).ThenInclude(s => s.Service).Where(c => c.IdentityUserId == userId).FirstOrDefault();
			if (customer == null)
			{
				return NotFound(); 
			}
			return View(customer.Account.Service);

		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditService([Bind("Id, DayOfService, NextServiceDay, IsOnHold, OneTimeService, StartServiceHold, EndServiceHold")]Service service)
		{
			//var serviceToUpdate = _context.Services.Where(s => s.Id == service.Id).FirstOrDefault();//query service table 
			if (_context.Services.Where(s => s.Id == service.Id).Any() == false)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{ 
				try
				{
					service.NextServiceDay = service.DayOfService;
					if (service.NextServiceDay.Equals(service.DayOfService))
					{
						service.NextServiceDay = service.NextServiceDay.AddDays(7);
					}
					_context.Update(service);
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (_context.Services.Any(s => s.Id == service.Id) == false)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View();
		}
		public IActionResult AccountDetails()
		{
			var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return NotFound();
			}
			var customer = _context.Customers.Include(a => a.Address).Include(c => c.Account).ThenInclude(s => s.Service).Where(c => c.IdentityUserId == userId).FirstOrDefault();
			if (customer == null)
			{
				return NotFound();
			}
			CustomerViewModel customerViewModel = new CustomerViewModel()
			{
				Customer = customer,
				Address = customer.Address,
				Account = customer.Account,
				Service = customer.Account.Service
			};
			return View(customerViewModel);
		}
	}
}
