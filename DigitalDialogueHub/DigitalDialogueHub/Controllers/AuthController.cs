using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
    [HttpPost("select-role")]
    public async Task<IActionResult> SelectRole([FromBody] RoleSelectDto dto)
    {
        try
        {
            var result = await _authService.SelectRoleAsync(dto);
            return Ok(new { message = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest dto)
    {
        try
        {
            var result = await _authService.RefreshTokenAsync(dto.Token, dto.RefreshToken);
            return Ok(new { Token = result });
        }
        catch (SecurityTokenException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }



    [HttpPost("Logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutDto dto)
    {
        var result = await _authService.RevokeRefreshTokenAsync(dto.RefreshToken);
        if (!result)
            return BadRequest(new { message = "Nevažeći refresh token." });

        return Ok(new { message = "Logout uspješan." });
    }

}