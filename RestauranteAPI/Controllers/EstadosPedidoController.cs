using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstadosPedidoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EstadosPedidoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadoPedido>>> GetAll()
    {
        var estados = await _context.EstadosPedido.ToListAsync();
        return Ok(estados);
    }
}
