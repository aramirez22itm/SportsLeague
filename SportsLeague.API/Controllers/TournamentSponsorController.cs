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