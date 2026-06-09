using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenService _service;

    public OrdenesController(IOrdenService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Orden>>> GetAll()
    {
        var ordenes = await _service.GetAllAsync();
        return Ok(ordenes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Orden>> GetById(int id)
    {
        var orden = await _service.GetByIdAsync(id);
        if (orden == null)
            return NotFound();

        return Ok(orden);
    }

    [HttpPost]
    public async Task<ActionResult<Orden>> Create(Orden orden)
    {
        var created = await _service.CreateAsync(orden);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Orden orden)
    {
        if (id != orden.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(orden);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<Orden> patchDoc)
    {
        var orden = await _service.GetByIdAsync(id);
        if (orden == null)
            return NotFound();

        patchDoc.ApplyTo(orden);
        await _service.UpdateAsync(orden);
        return NoContent();
    }

    [HttpPatch("{id}/estado")]
    public async Task<IActionResult> UpdateEstado(int id, [FromBody] EstadoUpdate estadoUpdate)
    {
        var result = await _service.UpdateEstadoAsync(id, estadoUpdate.Estado);
        if (!result)
            return NotFound();

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

public class EstadoUpdate
{
    public string Estado { get; set; } = null!;
}
