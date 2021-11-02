using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; } // Primary key

        // Required properties
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        // Optional property
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
