namespace EduTrack.Api.Models.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // Link to ApplicationUser
    public int UserId { get; set; }

    public ApplicationUser User { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();

    public ICollection<StudentTask> StudentTasks { get; set; }
        = new List<StudentTask>();
}