using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[ForeignKey("IdentityUser")]
		public string IdtentityUserId { get; set; }
		public IdentityUser IdentityUser { get; set; }

		//TODO add zip code
	}
}
