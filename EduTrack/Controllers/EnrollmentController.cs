using EduTrack.Api.Models.Entities;
using EduTrack.Api.Responses;
using EduTrack.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _service;

    public EnrollmentController(IEnrollmentService service)
    {
        _service = service;
    }

    // GET: api/Enrollment
    [HttpGet]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetAll()
    {
        var enrollments = await _service.GetAllEnrollmentsAsync();

        return Ok(new ApiResponse<IEnumerable<Enrollment>>(
            true,
            "Enrollments retrieved successfully.",
            enrollments));
    }

    // GET: api/Enrollment/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetById(int id)
    {
        var enrollment = await _service.GetEnrollmentByIdAsync(id);

        return Ok(new ApiResponse<Enrollment>(
            true,
            "Enrollment retrieved successfully.",
            enrollment));
    }

    // POST: api/Enrollment
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Enrollment enrollment)
    {
        var createdEnrollment = await _service.CreateEnrollmentAsync(enrollment);

        return Ok(new ApiResponse<Enrollment>(
            true,
            "Enrollment created successfully.",
            createdEnrollment));
    }

    // DELETE: api/Enrollment/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteEnrollmentAsync(id);

        return Ok(new ApiResponse<string>(
            true,
            "Enrollment deleted successfully.",
            null));
    }
}