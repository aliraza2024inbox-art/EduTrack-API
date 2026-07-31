namespace EduTrack.Api.Models.DTOs.Auth;

/// <summary>
/// Represents the information required to register a new user.
/// </summary>
public class RegisterDto
{
    /// <summary>
    /// User email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User password.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// User role. Default is Student.
    /// </summary>
    public string Role { get; set; } = "Student";
}