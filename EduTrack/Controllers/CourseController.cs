using EduTrack.Api.Models.Entities;
using EduTrack.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // GET: api/Course
    [HttpGet]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    // GET: api/Course/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetCourse(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // GET: api/Course/5/students
    [HttpGet("{id}/students")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetCourseWithStudents(int id)
    {
        var course = await _courseService.GetCourseWithStudentsAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // POST: api/Course
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateCourse([FromBody] Course course)
    {
        await _courseService.CreateCourseAsync(course);

        return Ok(new
        {
            Message = "Course created successfully."
        });
    }

    // PUT: api/Course/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
    {
        var success = await _courseService.UpdateCourseAsync(id, course);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Course updated successfully."
        });
    }

    // DELETE: api/Course/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var success = await _courseService.DeleteCourseAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Course deleted successfully."
        });
    }
}