using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/Student
    [HttpGet]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    // GET: api/Student/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // GET: api/Student/5/courses
    [HttpGet("{id}/courses")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetStudentWithCourses(int id)
    {
        var student = await _studentService.GetStudentWithCoursesAsync(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // POST: api/Student
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto studentDto)
    {
        var success = await _studentService.CreateStudentAsync(studentDto);

        if (!success)
            return BadRequest();

        return Ok(new
        {
            Message = "Student created successfully."
        });
    }

    // PUT: api/Student/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto studentDto)
    {
        var success = await _studentService.UpdateStudentAsync(id, studentDto);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Student updated successfully."
        });
    }

    // DELETE: api/Student/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var success = await _studentService.DeleteStudentAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Student deleted successfully."
        });
    }
}