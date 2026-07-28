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
    private readonly ICourseService _service;

    public CourseController(ICourseService service)
    {
        _service = service;
    }

    // GET: api/Course
    [HttpGet]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllCoursesAsync());
    }

    // GET: api/Course/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _service.GetCourseByIdAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // GET: api/Course/5/students
    [HttpGet("{id}/students")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetStudents(int id)
    {
        var course = await _service.GetCourseWithStudentsAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // POST: api/Course
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Course course)
    {
        await _service.CreateCourseAsync(course);

        return Ok(new
        {
            Message = "Course created successfully."
        });
    }

    // DELETE: api/Course/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteCourseAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Course deleted successfully."
        });
    }
}