using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Student_Courses_and_Info_Q2.Data;
using Student_Courses_and_Info_Q2.Models;
using Student_Courses_and_Info_Q2.ViewModels;
using System.Linq;

namespace Student_Courses_and_Info_Q2.Pages
{
    public class AddStudentModel : PageModel
    {
        private readonly StudentCoursesContext _context;
        private readonly ILogger<AddStudentModel> _logger;

        public AddStudentModel(StudentCoursesContext context, ILogger<AddStudentModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    foreach (var error in ModelState[modelStateKey].Errors)
                    {
                        _logger.LogError($"ModelState error for {modelStateKey}: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            var courseExists = _context.Courses.Any(c => c.CourseId == StudentViewModel.Course_ID);
            if (!courseExists)
            {
                ModelState.AddModelError("StudentViewModel.CourseId", "The specified course does not exist.");
                return Page();
            }

            var student = new Student
            {
                Name = StudentViewModel.Student_Name,
                City = StudentViewModel.City,
                CourseId = StudentViewModel.Course_ID
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToPage("./StudentInfo");
        }
    }
}
