using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student?> GetStudentWithCoursesAsync(int id);
}