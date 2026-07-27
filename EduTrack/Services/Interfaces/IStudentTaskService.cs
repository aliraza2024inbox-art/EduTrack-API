using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface IStudentTaskService
{
    Task<IEnumerable<StudentTask>> GetAllTasksAsync();

    Task<IEnumerable<StudentTask>> GetTasksByStudentIdAsync(int studentId);

    Task<StudentTask?> GetTaskByIdAsync(int id);

    Task CreateTaskAsync(StudentTask task);

    Task<bool> DeleteTaskAsync(int id);
}