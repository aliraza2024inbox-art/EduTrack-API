using EduTrack.Api.Models.DTOs.Student;

namespace EduTrack.Api.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync();

    Task<StudentDto?> GetStudentByIdAsync(int id);

    Task<StudentDto?> GetStudentWithCoursesAsync(int id);

    Task<bool> CreateStudentAsync(CreateStudentDto studentDto);

    Task<bool> UpdateStudentAsync(int id, UpdateStudentDto studentDto);

    Task<bool> DeleteStudentAsync(int id);
}