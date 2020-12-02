using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
	public class Swimmer
	{
		public int SwimmerId { get; set; }
		public string SwimmerName { get; set; }
		public string UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }

	}
}
