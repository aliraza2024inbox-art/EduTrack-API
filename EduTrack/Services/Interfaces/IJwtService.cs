using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(ApplicationUser user);
}