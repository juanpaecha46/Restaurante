using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediosPagoController : ControllerBase
{
    private readonly IMedioPagoService _service;

    public MediosPagoController(IMedioPagoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedioPago>>> GetAll()
    {
        var medios = await _service.GetAllAsync();
        return Ok(medios);
    }

    [HttpPost]
    public async Task<ActionResult<MedioPago>> Create(MedioPago medioPago)
    {
        var created = await _service.CreateAsync(medioPago);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MedioPago>> GetById(int id)
    {
        var medio = await _service.GetByIdAsync(id);
        if (medio == null)
            return NotFound();

        return Ok(medio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MedioPago medioPago)
    {
        if (id != medioPago.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(medioPago);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<MedioPago> patchDoc)
    {
        var medio = await _service.GetByIdAsync(id);
        if (medio == null)
            return NotFound();

        patchDoc.ApplyTo(medio);
        await _service.UpdateAsync(medio);
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
