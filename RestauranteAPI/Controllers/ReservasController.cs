using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly IReservaService _service;

    public ReservasController(IReservaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> GetAll()
    {
        var reservas = await _service.GetAllAsync();
        return Ok(reservas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reserva>> GetById(int id)
    {
        var reserva = await _service.GetByIdAsync(id);
        if (reserva == null)
            return NotFound();

        return Ok(reserva);
    }

    [HttpPost]
    public async Task<ActionResult<Reserva>> Create(Reserva reserva)
    {
        var created = await _service.CreateAsync(reserva);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Reserva reserva)
    {
        if (id != reserva.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(reserva);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<Reserva> patchDoc)
    {
        var reserva = await _service.GetByIdAsync(id);
        if (reserva == null)
            return NotFound();

        patchDoc.ApplyTo(reserva);
        await _service.UpdateAsync(reserva);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
