using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }

    public async Task<Course?> GetCourseWithStudentsAsync(int id)
    {
        return await _courseRepository.GetCourseWithStudentsAsync(id);
    }

    public async Task<bool> CreateCourseAsync(Course course)
    {
        await _courseRepository.AddAsync(course);
        return true;
    }

    public async Task<bool> UpdateCourseAsync(int id, Course course)
    {
        var existing = await _courseRepository.GetByIdAsync(id);

        if (existing == null)
            return false;

        existing.CourseName = course.CourseName;
        existing.CourseCode = course.CourseCode;
        existing.CreditHours = course.CreditHours;

        _courseRepository.Update(existing);

        return true;
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course == null)
            return false;

        _courseRepository.Delete(course);

        return true;
    }
}