using System.ComponentModel.DataAnnotations;

namespace Student_Courses_and_Info_Q2.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Course_Name { get; set; }

        [Required]
        public string Lecturer_Name { get; set; }
    }
}
