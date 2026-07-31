using EduTrack.Api.Models.DTOs.Auth;
using EduTrack.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduTrack.Api.Controllers;

/// <summary>
/// Handles user authentication and authorization operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="authService">Authentication service.</param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="dto">User registration details.</param>
    /// <returns>A success message if registration succeeds.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);

        if (!result)
            return BadRequest("Email already exists.");

        return Ok("User registered successfully.");
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    /// <param name="dto">User login credentials.</param>
    /// <returns>A JWT token if authentication succeeds.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _authService.LoginAsync(dto);

        if (token == null)
            return Unauthorized("Invalid email or password.");

        return Ok(new
        {
            Token = token
        });
    }
}