using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Email y contraseña son requeridos");

        var (success, token) = await _service.LoginAsync(request.Email, request.Password);
        
        if (!success)
            return Unauthorized("Email o contraseña inválidos");

        return Ok(new { token });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        var result = await _service.LogoutAsync(request.UsuarioId);
        if (!result)
            return BadRequest();

        return Ok("Sesión cerrada exitosamente");
    }

    [HttpPost("recuperar-password")]
    public async Task<IActionResult> RecuperarPassword([FromBody] RecuperarPasswordRequest request)
    {
        var result = await _service.RecuperarPasswordAsync(request.Email);
        if (!result)
            return NotFound("Usuario no encontrado");

        return Ok("Se ha enviado un email de recuperación");
    }

    [HttpPatch("cambiar-password")]
    public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordRequest request)
    {
        var result = await _service.CambiarPasswordAsync(request.UsuarioId, request.PasswordActual, request.NuevaPassword);
        if (!result)
            return BadRequest("Contraseña actual inválida");

        return NoContent();
    }

    [HttpGet("perfil")]
    public async Task<IActionResult> GetPerfil([FromQuery] int usuarioId)
    {
        var usuario = await _service.GetPerfilAsync(usuarioId);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }
}

public class LoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LogoutRequest
{
    public int UsuarioId { get; set; }
}

public class RecuperarPasswordRequest
{
    public string Email { get; set; } = null!;
}

public class CambiarPasswordRequest
{
    public int UsuarioId { get; set; }
    public string PasswordActual { get; set; } = null!;
    public string NuevaPassword { get; set; } = null!;
}
