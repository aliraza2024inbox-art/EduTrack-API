using AutoMapper;
using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }

    public async Task<StudentDto> GetStudentByIdAsync(int id)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student == null)
            throw new KeyNotFoundException($"Student with ID {id} was not found.");

        return _mapper.Map<StudentDto>(student);
    }

    public async Task<StudentDto> CreateStudentAsync(CreateStudentDto dto)
    {
        var student = _mapper.Map<Student>(dto);

        await _repository.AddAsync(student);

        return _mapper.Map<StudentDto>(student);
    }

    public async Task<StudentDto> UpdateStudentAsync(int id, UpdateStudentDto dto)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student == null)
            throw new KeyNotFoundException($"Student with ID {id} was not found.");

        _mapper.Map(dto, student);

        _repository.Update(student);
        await _repository.SaveChangesAsync();

        return _mapper.Map<StudentDto>(student);
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student == null)
            throw new KeyNotFoundException($"Student with ID {id} was not found.");

        _repository.Delete(student);
        await _repository.SaveChangesAsync();
    }
}