using System.ComponentModel.DataAnnotations;

namespace Student_Courses_and_Info_Q2.ViewModels
{
    public class StudentViewModel
    {
        [Required]
        public string Student_Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Course_ID { get; set; }
    }
}
