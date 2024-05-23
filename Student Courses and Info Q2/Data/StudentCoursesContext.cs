using Microsoft.EntityFrameworkCore;
using Student_Courses_and_Info_Q2.Models;

namespace Student_Courses_and_Info_Q2.Data
{
    public class StudentCoursesContext : DbContext
    {
        public StudentCoursesContext(DbContextOptions<StudentCoursesContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);
        }
    }
}
