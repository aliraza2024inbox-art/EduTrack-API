using EduTrack.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public DbSet<StudentTask> StudentTasks => Set<StudentTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);

        modelBuilder.Entity<StudentTask>()
            .HasOne(t => t.Student)
            .WithMany(s => s.StudentTasks)
            .HasForeignKey(t => t.StudentId);

        modelBuilder.Entity<StudentTask>()
            .HasOne(t => t.Course)
            .WithMany(c => c.StudentTasks)
            .HasForeignKey(t => t.CourseId);
    }
}