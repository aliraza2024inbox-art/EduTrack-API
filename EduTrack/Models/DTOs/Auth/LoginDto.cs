namespace EduTrack.Api.Models.DTOs.Auth;

/// <summary>
/// Represents the information required to authenticate a user.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// User email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User password.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}