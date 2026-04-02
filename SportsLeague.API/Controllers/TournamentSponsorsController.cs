using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class TournamentSponsorsController : ControllerBase
{
    private readonly IGenericRepository<TournamentSponsor> _repository;

    public TournamentSponsorsController(IGenericRepository<TournamentSponsor> repository)
    {
        _repository = repository;
    }

    // Actualizar Monto del Contrato (Update)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAmount(int id, decimal newAmount)
    {
        var link = await _repository.GetByIdAsync(id);
        if (link == null) return NotFound();

        link.ContractAmount = newAmount;

        _repository.Update(link); // SIN await porque devuelve void
        await _repository.SaveAsync(); // CON await para guardar en SQL

        return Ok(link);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLink(int id)
    {
        var link = await _repository.GetByIdAsync(id);
        if (link == null) return NotFound();

        _repository.Delete(link); // SIN await porque devuelve void
        await _repository.SaveAsync(); // CON await para guardar en SQL

        return NoContent();
    }
}