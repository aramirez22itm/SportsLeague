using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SponsorController : ControllerBase
{
    private readonly ISponsorService _service;

    public SponsorController(ISponsorService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SponsorRequestDTO request)
    {
        try
        {
            var response = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message); // Aquí cae si el nombre está duplicado
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _service.GetByIdAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent(); // Retorna 204 si todo salió bien
    }
}
