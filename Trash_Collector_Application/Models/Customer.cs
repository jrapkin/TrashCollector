using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Display]
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[ForeignKey("IdentityUser")]
		public string IdentityUserId { get; set; }
		public IdentityUser IdentityUser { get; set; }
		[ForeignKey("Address")]
		public int AddressId { get; set; }
		public Address Address { get; set; }
		[ForeignKey("Account")]
		public int? AccountId { get; set; }
		public Account Account { get; set; }

	}
}
