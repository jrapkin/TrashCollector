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
		public int ServiceId { get; set; }
		public DayOfWeek DayOfService { get; set; }
		public DateTime NextServiceDay { get; set; }
		public bool IsOnHold { get; set; }
		public DateTime OneTimeService { get; set; }
		public DateTime StartServiceHold { get; set; }
		public DateTime EndServiceHold { get; set; }

	}
}
