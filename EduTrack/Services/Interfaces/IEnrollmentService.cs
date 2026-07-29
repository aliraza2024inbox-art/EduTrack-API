using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface IEnrollmentService
{
    Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();

    Task<Enrollment> GetEnrollmentByIdAsync(int id);

    Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment);

    Task DeleteEnrollmentAsync(int id);
}