using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student_Courses_and_Info_Q2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LecturerName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
