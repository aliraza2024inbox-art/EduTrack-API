using EduTrack.Api.Models.Entities;
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
        var data = await _service.GetAllEnrollmentsAsync();
        return Ok(data);
    }

    // GET: api/Enrollment/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetById(int id)
    {
        var enrollment = await _service.GetEnrollmentByIdAsync(id);

        if (enrollment == null)
            return NotFound();

        return Ok(enrollment);
    }

    // POST: api/Enrollment
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Enrollment enrollment)
    {
        await _service.CreateEnrollmentAsync(enrollment);

        return Ok(new
        {
            Message = "Enrollment created successfully."
        });
    }

    // DELETE: api/Enrollment/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteEnrollmentAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Enrollment deleted successfully."
        });
    }
}