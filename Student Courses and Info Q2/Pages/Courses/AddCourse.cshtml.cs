using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Student_Courses_and_Info_Q2.Data;
using Student_Courses_and_Info_Q2.Models;
using Student_Courses_and_Info_Q2.ViewModels;

namespace Student_Courses_and_Info_Q2.Pages
{
    public class AddCourseModel : PageModel
    {
        private readonly StudentCoursesContext _context;
        private readonly ILogger<AddCourseModel> _logger;

        public AddCourseModel(StudentCoursesContext context, ILogger<AddCourseModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public CourseViewModel CourseViewModel { get; set; }

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

            var course = new Course
            {
                Name = CourseViewModel.Course_Name,
                LecturerName = CourseViewModel.Lecturer_Name
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToPage("../Students/StudentInfo");
        }
    }
}
