using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.DTOs.Response;
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
    public async Task<IActionResult> Update(int id, UpdateTournamentSponsorDTO dto)
    {
        var link = await _repository.GetByIdAsync(id);
        if (link == null) return NotFound();

        // Aplicar lógica de dominio
        link.UpdateContractAmount(dto.ContractAmount);

        _repository.Update(link);
        await _repository.SaveAsync();

        // Convertir a Response DTO
        var response = TournamentSponsorResponseDTO.FromEntity(link);

        return Ok(response);
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