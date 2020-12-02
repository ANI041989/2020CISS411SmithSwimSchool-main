using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int CoachId { get; set; } 
        public Coach Coach { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
