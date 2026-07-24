namespace EduTrack.Api.Models.Entities;

public enum TaskStatus
{
    Pending,
    InProgress,
    Done
}

public class StudentTask
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public TaskStatus Status { get; set; }

    public Student Student { get; set; } = null!;

    public Course Course { get; set; } = null!;
}