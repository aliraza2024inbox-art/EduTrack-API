using AutoMapper;
using EduTrack.Api.Mappings;
using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Repositories.Interfaces;
using EduTrack.Api.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace EduTrack.Tests.Services;

public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly IMapper _mapper;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = config.CreateMapper();

        _studentService = new StudentService(
            _studentRepositoryMock.Object,
            _mapper);
    }

    [Fact]
    public async Task GetAllStudentsAsync_ShouldReturnAllStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "Raza",
                Email = "ali@test.com"
            },
            new Student
            {
                Id = 2,
                FirstName = "Ahmed",
                LastName = "Khan",
                Email = "ahmed@test.com"
            }
        };

        _studentRepositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(students);

        // Act
        var result = await _studentService.GetAllStudentsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);

        result.First().FirstName.Should().Be("Ali");
        result.Last().FirstName.Should().Be("Ahmed");
    }

    [Fact]
    public async Task GetStudentByIdAsync_ShouldReturnStudent_WhenStudentExists()
    {
        // Arrange
        var student = new Student
        {
            Id = 1,
            FirstName = "Ali",
            LastName = "Raza",
            Email = "ali@test.com"
        };

        _studentRepositoryMock
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(student);

        // Act
        var result = await _studentService.GetStudentByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.FirstName.Should().Be("Ali");
        result.LastName.Should().Be("Raza");
        result.Email.Should().Be("ali@test.com");
    }

    [Fact]
    public async Task CreateStudentAsync_ShouldCreateStudent()
    {
        // Arrange
        var dto = new CreateStudentDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@test.com"
        };

        _studentRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Student>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _studentService.CreateStudentAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.FirstName.Should().Be("John");
        result.LastName.Should().Be("Doe");
        result.Email.Should().Be("john@test.com");

        _studentRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<Student>()),
            Times.Once);
    }

    [Fact]
    public async Task UpdateStudentAsync_ShouldUpdateStudent_WhenStudentExists()
    {
        // Arrange
        var student = new Student
        {
            Id = 1,
            FirstName = "Ali",
            LastName = "Raza",
            Email = "ali@test.com"
        };

        var dto = new UpdateStudentDto
        {
            FirstName = "Syed",
            LastName = "Ali",
            Email = "syed@test.com"
        };

        _studentRepositoryMock
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(student);

        // Act
        var result = await _studentService.UpdateStudentAsync(1, dto);

        // Assert
        result.Should().NotBeNull();
        result.FirstName.Should().Be("Syed");
        result.LastName.Should().Be("Ali");
        result.Email.Should().Be("syed@test.com");

        _studentRepositoryMock.Verify(
            x => x.Update(It.IsAny<Student>()),
            Times.Once);

        _studentRepositoryMock.Verify(
            x => x.SaveChangesAsync(),
            Times.Once);
    }

    [Fact]
    public async Task UpdateStudentAsync_ShouldThrowException_WhenStudentNotFound()
    {
        // Arrange
        var dto = new UpdateStudentDto
        {
            FirstName = "Syed",
            LastName = "Ali",
            Email = "syed@test.com"
        };

        _studentRepositoryMock
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((Student?)null);

        // Act
        Func<Task> action = async () =>
            await _studentService.UpdateStudentAsync(1, dto);

        // Assert
        await action.Should()
            .ThrowAsync<KeyNotFoundException>()
            .WithMessage("Student with ID 1 was not found.");
    }
}