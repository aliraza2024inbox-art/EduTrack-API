using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null)
            throw new KeyNotFoundException($"Course with ID {id} was not found.");

        return course;
    }

    public async Task<Course> CreateCourseAsync(Course course)
    {
        await _repository.AddAsync(course);
        return course;
    }

    public async Task<Course> UpdateCourseAsync(int id, Course updatedCourse)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null)
            throw new KeyNotFoundException($"Course with ID {id} was not found.");

        course.CourseName = updatedCourse.CourseName;
        course.CourseCode = updatedCourse.CourseCode;
        course.CreditHours = updatedCourse.CreditHours;

        _repository.Update(course);
        await _repository.SaveChangesAsync();

        return course;
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null)
            throw new KeyNotFoundException($"Course with ID {id} was not found.");

        _repository.Delete(course);
        await _repository.SaveChangesAsync();
    }
}