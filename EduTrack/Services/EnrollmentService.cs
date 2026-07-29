using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services.Interfaces;

namespace EduTrack.Api.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repository;

    public EnrollmentService(IEnrollmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
    {
        var enrollment = await _repository.GetByIdAsync(id);

        if (enrollment == null)
            throw new KeyNotFoundException($"Enrollment with ID {id} was not found.");

        return enrollment;
    }

    public async Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment)
    {
        await _repository.AddAsync(enrollment);
        return enrollment;
    }

    public async Task DeleteEnrollmentAsync(int id)
    {
        var enrollment = await _repository.GetByIdAsync(id);

        if (enrollment == null)
            throw new KeyNotFoundException($"Enrollment with ID {id} was not found.");

        _repository.Delete(enrollment);
        await _repository.SaveChangesAsync();
    }
}