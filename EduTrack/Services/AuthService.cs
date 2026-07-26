using BCrypt.Net;
using EduTrack.Api.Data;
using EduTrack.Api.Models.DTOs.Auth;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Models.Entities.Enums;
using EduTrack.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthService(
        AppDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        var exists = await _context.Users
            .AnyAsync(x => x.Email == dto.Email);

        if (exists)
            return false;

        if (!Enum.TryParse<Role>(dto.Role, true, out var role))
        {
            role = Role.Student;
        }

        var user = new ApplicationUser
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = role.ToString()
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
            return null;

        bool valid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash);

        if (!valid)
            return null;

        return _jwtService.GenerateToken(user);
    }
}