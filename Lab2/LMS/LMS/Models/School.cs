using System.Collections.Generic;
using LMS.Models.Relationships;
using LMS.Models.Students;

namespace LMS.Models
{
    public class School
    {
        // School Primary Info
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }

        // School Staff Info
        public Guid PrincipalId { get; set; } // Add PrincipalId property
        public Principal Principal { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}