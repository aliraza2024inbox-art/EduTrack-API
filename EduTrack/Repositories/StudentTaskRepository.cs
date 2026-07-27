using EduTrack.Api.Data;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Api.Repositories;

public class StudentTaskRepository : GenericRepository<StudentTask>, IStudentTaskRepository
{
    public StudentTaskRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<StudentTask>> GetTasksByStudentIdAsync(int studentId)
    {
        return await _context.StudentTasks
            .Where(t => t.StudentId == studentId)
            .ToListAsync();
    }
}