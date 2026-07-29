using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCoursesAsync();

    Task<Course> GetCourseByIdAsync(int id);

    Task<Course> CreateCourseAsync(Course course);

    Task<Course> UpdateCourseAsync(int id, Course course);

    Task DeleteCourseAsync(int id);
}