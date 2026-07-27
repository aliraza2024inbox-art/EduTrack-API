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

    public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateEnrollmentAsync(Enrollment enrollment)
    {
        await _repository.AddAsync(enrollment);
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        var enrollment = await _repository.GetByIdAsync(id);

        if (enrollment == null)
            return false;

        _repository.Delete(enrollment);
        await _repository.SaveChangesAsync();

        return true;
    }
}