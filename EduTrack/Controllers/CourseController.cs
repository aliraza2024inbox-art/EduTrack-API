using EduTrack.Api.Models.Entities;
using EduTrack.Api.Responses;
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
        var courses = await _service.GetAllCoursesAsync();

        return Ok(new ApiResponse<IEnumerable<Course>>(
            true,
            "Courses retrieved successfully.",
            courses));
    }

    // GET: api/Course/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _service.GetCourseByIdAsync(id);

        return Ok(new ApiResponse<Course>(
            true,
            "Course retrieved successfully.",
            course));
    }

    // POST: api/Course
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Course course)
    {
        var createdCourse = await _service.CreateCourseAsync(course);

        return Ok(new ApiResponse<Course>(
            true,
            "Course created successfully.",
            createdCourse));
    }

    // PUT: api/Course/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> Update(int id, Course course)
    {
        var updatedCourse = await _service.UpdateCourseAsync(id, course);

        return Ok(new ApiResponse<Course>(
            true,
            "Course updated successfully.",
            updatedCourse));
    }

    // DELETE: api/Course/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteCourseAsync(id);

        return Ok(new ApiResponse<string>(
            true,
            "Course deleted successfully.",
            null));
    }
}