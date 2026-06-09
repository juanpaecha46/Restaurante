using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdicionesController : ControllerBase
{
    private readonly IAdicionService _service;

    public AdicionesController(IAdicionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Adicion>>> GetAll()
    {
        var adiciones = await _service.GetAllAsync();
        return Ok(adiciones);
    }

    [HttpPost]
    public async Task<ActionResult<Adicion>> Create(Adicion adicion)
    {
        var created = await _service.CreateAsync(adicion);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Adicion>> GetById(int id)
    {
        var adicion = await _service.GetByIdAsync(id);
        if (adicion == null)
            return NotFound();

        return Ok(adicion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Adicion adicion)
    {
        if (id != adicion.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(adicion);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<Adicion> patchDoc)
    {
        var adicion = await _service.GetByIdAsync(id);
        if (adicion == null)
            return NotFound();

        patchDoc.ApplyTo(adicion);
        await _service.UpdateAsync(adicion);
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
