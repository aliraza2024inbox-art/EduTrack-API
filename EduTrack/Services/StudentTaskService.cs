using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class StudentTaskService : IStudentTaskService
{
    private readonly IStudentTaskRepository _repository;

    public StudentTaskService(IStudentTaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StudentTask>> GetAllTasksAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<StudentTask>> GetTasksByStudentIdAsync(int studentId)
    {
        return await _repository.GetTasksByStudentIdAsync(studentId);
    }

    public async Task<StudentTask?> GetTaskByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateTaskAsync(StudentTask task)
    {
        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
            return false;

        _repository.Delete(task);
        await _repository.SaveChangesAsync();

        return true;
    }
}