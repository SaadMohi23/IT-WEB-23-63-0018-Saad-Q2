using System.Collections.Generic;
using System.Linq; // Add this using directive
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // Add this using directive
using Student_Courses_and_Info_Q2.Data;
using Student_Courses_and_Info_Q2.Models;

namespace Student_Courses_and_Info_Q2.Pages
{
    public class StudentInfoModel : PageModel
    {
        private readonly StudentCoursesContext _context;

        public StudentInfoModel(StudentCoursesContext context)
        {
            _context = context;
            Students = new List<Student>(); // Initialize Students property
        }

        public List<Student> Students { get; set; }

        public void OnGet()
        {
            Students = _context.Students
                .Include(s => s.Course)
                .ToList(); // Use ToList() instead of ToListAsync().Result
        }
    }
}
