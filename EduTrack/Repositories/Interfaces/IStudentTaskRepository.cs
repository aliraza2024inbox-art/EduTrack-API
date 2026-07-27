using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Repositories.Interfaces;

public interface IStudentTaskRepository : IGenericRepository<StudentTask>
{
    Task<IEnumerable<StudentTask>> GetTasksByStudentIdAsync(int studentId);
}