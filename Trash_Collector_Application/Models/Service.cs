﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector_Application.Models
{
	public class Service
	{
		[Key]
		public int Id { get; set; }
		[Display (Name = "Day of Service")]
		public DayOfWeek DayOfService { get; set; }
		public DateTime NextServiceDay { get; set; }
		public bool IsOnHold { get; set; }
		public bool ServiceIsCompleted { get; set; }
		[Display(Name = "One Time Service")]
		public DateTime? OneTimeService { get; set; }
		[Display(Name = "Suspend Service")]
		public DateTime? StartServiceHold { get; set; }
		[Display(Name = "End Service Hold")]
		public DateTime? EndServiceHold { get; set; }

	}
}
