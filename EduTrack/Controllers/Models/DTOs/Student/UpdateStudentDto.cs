namespace EduTrack.Api.Models.DTOs.Student;

public class UpdateStudentDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }
}