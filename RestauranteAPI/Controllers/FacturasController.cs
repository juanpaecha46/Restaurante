using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using RestauranteAPI.Models;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturasController : ControllerBase
{
    private readonly IFacturaService _service;

    public FacturasController(IFacturaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
    {
        var facturas = await _service.GetAllAsync();
        return Ok(facturas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Factura>> GetById(int id)
    {
        var factura = await _service.GetByIdAsync(id);
        if (factura == null)
            return NotFound();

        return Ok(factura);
    }

    [HttpPost]
    public async Task<ActionResult<Factura>> Create(Factura factura)
    {
        var created = await _service.CreateAsync(factura);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Factura factura)
    {
        if (id != factura.Id)
            return BadRequest();

        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _service.UpdateAsync(factura);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<Factura> patchDoc)
    {
        var factura = await _service.GetByIdAsync(id);
        if (factura == null)
            return NotFound();

        patchDoc.ApplyTo(factura);
        await _service.UpdateAsync(factura);
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
