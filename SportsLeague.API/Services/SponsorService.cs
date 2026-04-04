using AutoMapper;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.DTOs.Response;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Services;

public class SponsorService : ISponsorService
{
    private readonly ISponsorRepository _repository;
    private readonly IMapper _mapper;

    public SponsorService(ISponsorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SponsorResponseDTO> CreateAsync(SponsorRequestDTO request)
    {
        // Validación obligatoria: Nombre duplicado 
        if (await _repository.ExistsByNameAsync(request.Name))
            throw new InvalidOperationException("A sponsor with this name already exists.");

        var entity = _mapper.Map<Sponsor>(request);
        await _repository.AddAsync(entity); // Método heredado del genérico [cite: 49]
        await _repository.SaveAsync();
        return _mapper.Map<SponsorResponseDTO>(entity);
    }

    public async Task<SponsorResponseDTO?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<SponsorResponseDTO>(entity);
    }

    public async Task<IEnumerable<SponsorResponseDTO>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync(); // Usa el método del repositorio genérico
        return _mapper.Map<IEnumerable<SponsorResponseDTO>>(entities);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.Delete(entity); // Usa el Delete del GenericRepository
        await _repository.SaveAsync();

        return true;
    }
    public async Task<bool> UpdateAsync(int id, Sponsor sponsor)
    {
        // var existingSponsor = await _repository.GetByIdAsync(id);
        // if (existingSponsor == null) return false;

        // Actualizamos los datos
        _repository.Update(sponsor);
        return await _repository.SaveAsync();
    }
}