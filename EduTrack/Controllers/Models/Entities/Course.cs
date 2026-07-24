using EduTrack.Api.Controllers.Models.Entities;

namespace EduTrack.Api.Models.Entities;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CreditHours { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();

    public ICollection<StudentTask> StudentTasks { get; set; }
        = new List<StudentTask>();
}