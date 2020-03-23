using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class Account
	{
		[Key]
		public int Id { get; set; }
		public double? AccountBalance { get; set; }
		[ForeignKey("Service")]
		public int ServiceId { get; set; }
		public Service Service { get; set; }
	}
}
