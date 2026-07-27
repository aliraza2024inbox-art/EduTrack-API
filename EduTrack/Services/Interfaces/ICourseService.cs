using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCoursesAsync();

    Task<Course?> GetCourseByIdAsync(int id);

    Task<Course?> GetCourseWithStudentsAsync(int id);

    Task<bool> CreateCourseAsync(Course course);

    Task<bool> UpdateCourseAsync(int id, Course course);

    Task<bool> DeleteCourseAsync(int id);
}