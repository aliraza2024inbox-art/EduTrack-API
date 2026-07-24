using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Repositories.Interfaces;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<Course?> GetCourseWithStudentsAsync(int id);
}