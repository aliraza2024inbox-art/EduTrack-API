using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Responses;
using EduTrack.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Api.Controllers;

/// <summary>
/// Provides endpoints for managing students.
/// </summary>
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

    /// <summary>
    /// Retrieves all students.
    /// </summary>
    /// <returns>A list of students.</returns>
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

    /// <summary>
    /// Retrieves a student by ID.
    /// </summary>
    /// <param name="id">Student ID.</param>
    /// <returns>The requested student.</returns>
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

    /// <summary>
    /// Creates a new student.
    /// </summary>
    /// <param name="studentDto">Student information.</param>
    /// <returns>The created student.</returns>
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

    /// <summary>
    /// Updates an existing student.
    /// </summary>
    /// <param name="id">Student ID.</param>
    /// <param name="studentDto">Updated student information.</param>
    /// <returns>The updated student.</returns>
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

    /// <summary>
    /// Deletes a student.
    /// </summary>
    /// <param name="id">Student ID.</param>
    /// <returns>Success message.</returns>
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