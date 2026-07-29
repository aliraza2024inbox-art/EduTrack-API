using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface IStudentTaskService
{
    Task<IEnumerable<StudentTask>> GetAllTasksAsync();

    Task<StudentTask> GetTaskByIdAsync(int id);

    Task<StudentTask> CreateTaskAsync(StudentTask task);

    Task<StudentTask> UpdateTaskAsync(int id, StudentTask task);

    Task DeleteTaskAsync(int id);
}