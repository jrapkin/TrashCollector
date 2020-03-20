using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trash_Collector_Application.Models;

namespace Trash_Collector_Application.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Account> Accounts { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityRole>()
				.HasData(
					new IdentityRole
					{
						Name = "Customer",
						NormalizedName = "CUSTOMER"
					},

					new IdentityRole
					{
						Name = "Employee",
						NormalizedName = "EMPLOYEE"
					}
				);
		}
	}
}
