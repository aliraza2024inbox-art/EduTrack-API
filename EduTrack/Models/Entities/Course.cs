namespace EduTrack.Api.Models.Entities;

public class Course : BaseEntity
{
    public string CourseName { get; set; } = string.Empty;

    public string CourseCode { get; set; } = string.Empty;

    public int CreditHours { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();

    public ICollection<StudentTask> StudentTasks { get; set; }
        = new List<StudentTask>();
}