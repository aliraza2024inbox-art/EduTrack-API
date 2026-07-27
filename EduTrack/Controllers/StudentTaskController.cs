using EduTrack.Api.Models.Entities;
using EduTrack.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentTaskController : ControllerBase
{
    private readonly IStudentTaskService _service;

    public StudentTaskController(IStudentTaskService service)
    {
        _service = service;
    }

    // GET: api/StudentTask
    [HttpGet]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllTasksAsync());
    }

    // GET: api/StudentTask/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _service.GetTaskByIdAsync(id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    // GET: api/StudentTask/student/3
    [HttpGet("student/{studentId}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetByStudent(int studentId)
    {
        var tasks = await _service.GetTasksByStudentIdAsync(studentId);

        return Ok(tasks);
    }

    // POST: api/StudentTask
    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> Create(StudentTask task)
    {
        await _service.CreateTaskAsync(task);

        return Ok(new
        {
            Message = "Task created successfully."
        });
    }

    // DELETE: api/StudentTask/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteTaskAsync(id);

        if (!success)
            return NotFound();

        return Ok(new
        {
            Message = "Task deleted successfully."
        });
    }
}