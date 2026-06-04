using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Models;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DomiciliosController : ControllerBase
{
    private readonly IDomicilioService _service;

    public DomiciliosController(IDomicilioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domicilio>>> GetAll()
    {
        var domicilios = await _service.GetAllAsync();
        return Ok(domicilios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Domicilio>> GetById(int id)
    {
        var domicilio = await _service.GetByIdAsync(id);
        if (domicilio == null)
            return NotFound();

        return Ok(domicilio);
    }

    [HttpPost]
    public async Task<ActionResult<Domicilio>> Create(Domicilio domicilio)
    {
        var created = await _service.CreateAsync(domicilio);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Domicilio domicilio)
    {
        if (id != domicilio.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(domicilio);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<Domicilio> patchDoc)
    {
        var domicilio = await _service.GetByIdAsync(id);
        if (domicilio == null)
            return NotFound();

        patchDoc.ApplyTo(domicilio);
        await _service.UpdateAsync(domicilio);
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
