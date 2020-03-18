using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class Service
	{
		[Key]
		public int ServiceId { get; set; }
	}
}
