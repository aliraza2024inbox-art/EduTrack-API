using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();

    Task<Student?> GetStudentByIdAsync(int id);

    Task<Student?> GetStudentWithCoursesAsync(int id);

    Task<bool> CreateStudentAsync(Student student);

    Task<bool> UpdateStudentAsync(Student student);

    Task<bool> DeleteStudentAsync(int id);
}