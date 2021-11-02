using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace StudentManagement
{
    class StudentContext : DbContext
    {
        public StudentContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentDatabase;Integrated Security=True");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var st1 = new Student()
            {
                StudentID = 1,
                FirstName = "Willemien",
                LastName = "Kuijk",
                DateOfBirth = new DateTime(1994, 2, 22)
            };

            var st2 = new Student()
            {
                StudentID = 2,
                FirstName = "Daan",
                LastName = "Seelen",
                DateOfBirth = new DateTime(1988, 7, 26)
            };

            var st3 = new Student()
            {
                StudentID = 3,
                FirstName = "Lisette",
                LastName = "Visser",
                DateOfBirth = new DateTime(1989, 2, 4)
            };

            modelBuilder.Entity<Student>().HasData(st1, st2, st3);

            var c1 = new Course()
            {
                CourseID = 1,
                Name = "HTML",
                Description = "Learn how to create your own webpage."
            };

            var c2 = new Course()
            {
                CourseID = 2,
                Name = "Python",
                Description = "Learn how to code using the very accessible language Python."
            };

            var c3 = new Course()
            {
                CourseID = 3,
                Name = ".NET",
                Description = "Learn how to create your complex applications using the Microsoft .NET Framework."
            };

            modelBuilder.Entity<Course>().HasData(c1, c2, c3);

            var e1 = new Enrollment()
            {
                EnrollmentID = 1,
                StudentID = st1.StudentID,
                CourseID = c1.CourseID
            };

            var e2 = new Enrollment()
            {
                EnrollmentID = 2,
                StudentID = st2.StudentID,
                CourseID = c1.CourseID
            };

            var e3 = new Enrollment()
            {
                EnrollmentID = 3,
                StudentID = st3.StudentID,
                CourseID = c2.CourseID
            };

            var e4 = new Enrollment()
            {
                EnrollmentID = 4,
                StudentID = st3.StudentID,
                CourseID = c3.CourseID
            };

            modelBuilder.Entity<Enrollment>().HasData(e1, e2, e3, e4);
        }
    }
}
