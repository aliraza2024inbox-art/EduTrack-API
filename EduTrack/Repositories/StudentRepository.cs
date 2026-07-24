using EduTrack.Api.Data;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Api.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Student?> GetStudentWithCoursesAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}