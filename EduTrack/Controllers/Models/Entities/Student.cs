namespace EduTrack.Api.Models.Entities;

public class Student
{
    public int Id { get; set; }

    // Foreign Key
    public int UserId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }

    // Navigation Property
    public ApplicationUser User { get; set; } = null!;

    // Navigation Collections
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public ICollection<StudentTask> StudentTasks { get; set; } = new List<StudentTask>();
}