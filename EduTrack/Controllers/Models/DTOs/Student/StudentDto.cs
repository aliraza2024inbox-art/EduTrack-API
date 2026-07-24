namespace EduTrack.Api.Models.DTOs.Student;

public class StudentDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }
}