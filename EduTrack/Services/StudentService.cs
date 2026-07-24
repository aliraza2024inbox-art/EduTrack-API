using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    public async Task<Student?> GetStudentWithCoursesAsync(int id)
    {
        return await _studentRepository.GetStudentWithCoursesAsync(id);
    }

    public async Task<bool> CreateStudentAsync(Student student)
    {
        await _studentRepository.AddAsync(student);
        return await _studentRepository.SaveChangesAsync();
    }

    public async Task<bool> UpdateStudentAsync(Student student)
    {
        _studentRepository.Update(student);
        return await _studentRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);

        if (student == null)
            return false;

        _studentRepository.Delete(student);

        return await _studentRepository.SaveChangesAsync();
    }
}