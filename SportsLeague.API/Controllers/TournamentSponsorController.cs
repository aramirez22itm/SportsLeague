using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class TournamentSponsorController : ControllerBase
{
    private readonly IGenericRepository<TournamentSponsor> _repository;
    private readonly IMapper _mapper;

    public TournamentSponsorController(IGenericRepository<TournamentSponsor> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TournamentSponsorRequestDTO request)
    {
        var entity = _mapper.Map<TournamentSponsor>(request);
        await _repository.AddAsync(entity);
        await _repository.SaveAsync();
        return Ok(entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
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
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TournamentSponsor tournamentSponsor)
    {
        // 1. Validación de Auditoría: ¿El ID de la URL coincide con el del objeto?
        if (id != tournamentSponsor.Id) return BadRequest("El ID no coincide");

        // 2. Ejecutar la actualización en el repositorio
        _repository.Update(tournamentSponsor);

        // 3. Guardar cambios en SQL
        var saved = await _repository.SaveAsync();

        if (!saved) return BadRequest("No se pudo actualizar el registro");

        return NoContent(); // Retorna 204: Todo salió bien
    }

}