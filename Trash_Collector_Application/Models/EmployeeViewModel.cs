using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class EmployeeViewModel
	{
		public Employee Employee { get; set; }
		public List <Customer> Customers { get; set; }
		
		public DateTime? DayForFilter { get; set; }
	}
}
