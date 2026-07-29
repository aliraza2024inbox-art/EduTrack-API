using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Responses;
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

        return Ok(new ApiResponse<IEnumerable<StudentDto>>(
            true,
            "Students retrieved successfully.",
            students));
    }

    // GET: api/Student/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);

        return Ok(new ApiResponse<StudentDto>(
            true,
            "Student retrieved successfully.",
            student));
    }

    // POST: api/Student
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateStudent(CreateStudentDto studentDto)
    {
        var student = await _studentService.CreateStudentAsync(studentDto);

        return Ok(new ApiResponse<StudentDto>(
            true,
            "Student created successfully.",
            student));
    }

    // PUT: api/Student/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto studentDto)
    {
        var student = await _studentService.UpdateStudentAsync(id, studentDto);

        return Ok(new ApiResponse<StudentDto>(
            true,
            "Student updated successfully.",
            student));
    }

    // DELETE: api/Student/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await _studentService.DeleteStudentAsync(id);

        return Ok(new ApiResponse<string>(
            true,
            "Student deleted successfully.",
            null));
    }
}