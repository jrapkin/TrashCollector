using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trash_Collector_Application.Data;
using Trash_Collector_Application.Models;

namespace Trash_Collector_Application.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_context.Employees.Where(e => e.IdentityUserId == userId).Any())
            {
                EmployeeViewModel employeeView = new EmployeeViewModel();
                var currentEmployee = _context.Employees.Where(e => e.IdentityUserId == userId).FirstOrDefault();
                employeeView.Employee = currentEmployee;
                var customers = GetAllCustomers();
                customers = GetCustomersByZip(customers, currentEmployee);
                employeeView.Customers = GetCustomersByDay(customers, employeeView);
                return View(employeeView);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EmployeeViewModel employeeViewFromForm)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_context.Employees.Where(e => e.IdentityUserId == userId).Any())
            {
                var employee = _context.Employees.Where(e => e.IdentityUserId == userId).FirstOrDefault();
                var customers = GetAllCustomers();
                customers = GetCustomersByZip(customers, employee);
                customers = GetCustomersByDay(customers, employeeViewFromForm);
                EmployeeViewModel employeeView = new EmployeeViewModel()
                {
                    Employee = employee,
                    Customers = customers,
                    DayForFilter = employeeViewFromForm.DayForFilter
                };
                return View(employeeView);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        public IActionResult ConfirmCompletedService(int accountId)
        {
            var customerAccount = _context.Accounts.Include(a => a.Service).Where(a => a.Id == accountId).FirstOrDefault();
            if (customerAccount.Service.NextServiceDay.Equals(DateTime.Today))
            {
                customerAccount.Service.NextServiceDay = customerAccount.Service.NextServiceDay.AddDays(7);
            }
            if(customerAccount.Service.OneTimeService.HasValue)
            {
                if (customerAccount.Service.OneTimeService.Equals(DateTime.Today.Date))
                {
                    customerAccount.Service.OneTimeService = null;
                }
            }
            customerAccount.Service.ServiceIsCompleted = true;
            customerAccount.AccountBalance += 50;
            _context.Accounts.Update(customerAccount);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdtentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName, ZipCode, IdentityUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Employee employeeToBeCreated = new Employee()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        ZipCode = employee.ZipCode,
                        IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };
                    _context.Add(employeeToBeCreated);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                //If we got this far something went wrong
                return View();
            }
        }

        public IActionResult CustomerDetails(int Id)
        {
            var customer = _context.Customers.Include(a =>a.Address).Where(c => c.Id ==Id).FirstOrDefault();
            return View(customer);
        }

        private List<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.Include(c => c.Address).Include(c => c.Account).ThenInclude(s => s.Service).ToList();
            return customers;
        }
        private List<Customer> GetCustomersByZip(List<Customer> customers, Employee employee)
        {
            customers = customers.Where(c => c.Address.ZipCode == employee.ZipCode).ToList();
            return customers;
        }
        private List<Customer> GetCustomersByDay(List<Customer> customers, EmployeeViewModel employeeView)
        {
            if (employeeView.DayForFilter == null)
            {
                customers = customers.Where(sd => sd.Account.Service.DayOfService.Equals(DateTime.Today.DayOfWeek) || sd.Account.Service.OneTimeService.Equals(DateTime.Today)).ToList();
            }
            if (employeeView.DayForFilter.HasValue)
            {
                customers = customers.Where(sd => sd.Account.Service.DayOfService.Equals(employeeView.DayForFilter) || sd.Account.Service.OneTimeService.Equals(employeeView.DayForFilter)).ToList();
            }
            return customers;
        }
    }
}
