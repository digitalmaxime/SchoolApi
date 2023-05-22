using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController: ControllerBase
{
    // public async Task<ICollection<Course>> GetAllCourses()
    [HttpGet]
    public async Task<ICollection<string>> GetAllCourses()
    {
        // var allCourses = await _schoolContext.Courses.ToListAsync();
        var allCourses = new List<string>
        {
            "abs", "tonus", "Math", "Pubis"
        };
        return allCourses;
        
    }

    // public async Task<Course?> GetCourseById(int id)
    // {
    //     var course = await _schoolContext.Courses
    //         .FirstOrDefaultAsync(c => c.CourseId == id);
    //
    //     return course;
    // }

    // public async Task<Course?> AddCourse(AddCourseDto request)
    // {
    //     var course = new Course
    //     {
    //         CourseName = request.CourseName,
    //         Location = request.Location
    //     };
    //
    //     _schoolContext.Add(course);
    //     await _schoolContext.SaveChangesAsync();
    //
    //     return course;
    // }
}