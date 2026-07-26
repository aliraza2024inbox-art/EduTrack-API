namespace EduTrack.Api.Models.DTOs.Student;

public class CreateStudentDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}