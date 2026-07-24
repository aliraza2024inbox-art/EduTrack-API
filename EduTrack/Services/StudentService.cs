using AutoMapper;
using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(
        IStudentRepository studentRepository,
        IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);

        if (student == null)
            return null;

        return _mapper.Map<StudentDto>(student);
    }

    public async Task<StudentDto?> GetStudentWithCoursesAsync(int id)
    {
        var student = await _studentRepository.GetStudentWithCoursesAsync(id);

        if (student == null)
            return null;

        return _mapper.Map<StudentDto>(student);
    }

    public async Task<bool> CreateStudentAsync(CreateStudentDto dto)
    {
        var student = _mapper.Map<Student>(dto);

        await _studentRepository.AddAsync(student);

        return await _studentRepository.SaveChangesAsync();
    }

    public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto)
    {
        var student = await _studentRepository.GetByIdAsync(id);

        if (student == null)
            return false;

        _mapper.Map(dto, student);

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