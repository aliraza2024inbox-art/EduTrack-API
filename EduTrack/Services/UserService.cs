using EduTrack.Api.Data;
using EduTrack.Api.Models.DTOs.User;
using EduTrack.Api.Models.Entities;
using EduTrack.Api.Models.Entities.Enums;
using EduTrack.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Api.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        return await _context.Users
            .Select(x => new UserDto
            {
                Id = x.Id,
                Email = x.Email,
                Role = x.Role
            })
            .ToListAsync();
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        return await _context.Users
            .Where(x => x.Id == id)
            .Select(x => new UserDto
            {
                Id = x.Id,
                Email = x.Email,
                Role = x.Role
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateUserRoleAsync(int id, UpdateUserRoleDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return false;

        if (!Enum.TryParse<Role>(dto.Role, true, out var role))
            return false;

        user.Role = role.ToString();

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return false;

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

        return true;
    }
}