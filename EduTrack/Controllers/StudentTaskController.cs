using EduTrack.Api.Models.Entities;
using EduTrack.Api.Responses;
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
        var tasks = await _service.GetAllTasksAsync();

        return Ok(new ApiResponse<IEnumerable<StudentTask>>(
            true,
            "Tasks retrieved successfully.",
            tasks));
    }

    // GET: api/StudentTask/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _service.GetTaskByIdAsync(id);

        return Ok(new ApiResponse<StudentTask>(
            true,
            "Task retrieved successfully.",
            task));
    }

    // POST: api/StudentTask
    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> Create(StudentTask task)
    {
        var createdTask = await _service.CreateTaskAsync(task);

        return Ok(new ApiResponse<StudentTask>(
            true,
            "Task created successfully.",
            createdTask));
    }

    // PUT: api/StudentTask/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<IActionResult> Update(int id, StudentTask task)
    {
        var updatedTask = await _service.UpdateTaskAsync(id, task);

        return Ok(new ApiResponse<StudentTask>(
            true,
            "Task updated successfully.",
            updatedTask));
    }

    // DELETE: api/StudentTask/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteTaskAsync(id);

        return Ok(new ApiResponse<string>(
            true,
            "Task deleted successfully.",
            null));
    }
}