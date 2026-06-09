using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DireccionesController : ControllerBase
{
    private readonly IDireccionService _service;

    public DireccionesController(IDireccionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Direccion>>> GetAll()
    {
        var direcciones = await _service.GetAllAsync();
        return Ok(direcciones);
    }

    [HttpPost]
    public async Task<ActionResult<Direccion>> Create(Direccion direccion)
    {
        var created = await _service.CreateAsync(direccion);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Direccion>> GetById(int id)
    {
        var direccion = await _service.GetByIdAsync(id);
        if (direccion == null)
            return NotFound();

        return Ok(direccion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Direccion direccion)
    {
        if (id != direccion.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(direccion);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<Direccion> patchDoc)
    {
        var direccion = await _service.GetByIdAsync(id);
        if (direccion == null)
            return NotFound();

        patchDoc.ApplyTo(direccion);
        await _service.UpdateAsync(direccion);
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
