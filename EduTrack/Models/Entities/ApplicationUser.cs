namespace EduTrack.Api.Models.Entities;

public class ApplicationUser : BaseEntity
{
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "Student";

    // One-to-One relationship with Student
    public Student? Student { get; set; }
}