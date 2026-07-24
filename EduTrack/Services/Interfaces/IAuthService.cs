using EduTrack.Api.Models.DTOs.Auth;

namespace EduTrack.Api.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto);

    Task<string?> LoginAsync(LoginDto dto);
}