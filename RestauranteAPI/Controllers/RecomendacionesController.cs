using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecomendacionesController : ControllerBase
{
    private readonly IRecomendacionService _service;

    public RecomendacionesController(IRecomendacionService service)
    {
        _service = service;
    }

    [HttpGet("{clienteId}")]
    public async Task<IActionResult> GetByClienteId(int clienteId)
    {
        var recomendaciones = await _service.GetByClienteIdAsync(clienteId);
        return Ok(recomendaciones);
    }

    [HttpPost("generar")]
    public async Task<IActionResult> GenerarRecomendaciones()
    {
        var recomendaciones = await _service.GenerarRecomendacionesAsync();
        return Ok(recomendaciones);
    }
}
