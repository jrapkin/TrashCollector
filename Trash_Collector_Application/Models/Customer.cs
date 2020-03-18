using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string Name { get; set; }
		[ForeignKey("")]
		public string IdtentityUserId { get; set; }
		public IdentityUser IdentityUser { get; set; }

	}
}
