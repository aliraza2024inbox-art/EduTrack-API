using EduTrack.Api.Data;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;

namespace EduTrack.Api.Repositories;

public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(AppDbContext context)
        : base(context)
    {
    }
}