using EduTrack.Api.Data;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Api.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Course?> GetCourseWithStudentsAsync(int id)
    {
        return await _context.Courses
            .Include(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}