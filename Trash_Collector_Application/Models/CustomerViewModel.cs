using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class CustomerViewModel
	{
		public Customer Customer { get; set; }
		public IdentityUser IdentityUser { get; set; }
		public Address Address { get; set; }
		public Service Service { get; set; }
	}
}
