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

    public async Task<StudentTask> GetTaskByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
            throw new KeyNotFoundException($"Task with ID {id} was not found.");

        return task;
    }

    public async Task<StudentTask> CreateTaskAsync(StudentTask task)
    {
        await _repository.AddAsync(task);
        return task;
    }

    public async Task<StudentTask> UpdateTaskAsync(int id, StudentTask updatedTask)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
            throw new KeyNotFoundException($"Task with ID {id} was not found.");

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;
        task.StudentId = updatedTask.StudentId;

        _repository.Update(task);
        await _repository.SaveChangesAsync();

        return task;
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
            throw new KeyNotFoundException($"Task with ID {id} was not found.");

        _repository.Delete(task);
        await _repository.SaveChangesAsync();
    }
}