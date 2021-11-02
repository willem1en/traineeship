using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        // Student relationship

        public int StudentID { get; set; }

        [ForeignKey(nameof(StudentID))]
        public virtual Student Student { get; set; }

        // Course relationship

        public int CourseID { get; set; }

        [ForeignKey(nameof(CourseID))]
        public virtual Course Course { get; set; }
    }
}
