using Microsoft.Extensions.Logging;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly ILogger<TeamService> _logger;

    public TeamService(ITeamRepository teamRepository, ILogger<TeamService> logger)
    {
        _teamRepository = teamRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _teamRepository.GetAllAsync();
    }

    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _teamRepository.GetByIdAsync(id);
    }

    public async Task<Team> CreateAsync(Team team)
    {
        var existing = await _teamRepository.GetByNameAsync(team.Name);
        if (existing != null)
            throw new InvalidOperationException($"Ya existe un equipo con el nombre '{team.Name}'");

        return await _teamRepository.CreateAsync(team);
    }

    public async Task UpdateAsync(int id, Team team)
    {
        var existing = await _teamRepository.GetByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException($"No se encontró el equipo con ID {id}");

        if (existing.Name != team.Name)
        {
            var conflict = await _teamRepository.GetByNameAsync(team.Name);
            if (conflict != null)
                throw new InvalidOperationException($"Ya existe un equipo con el nombre '{team.Name}'");
        }

        existing.Name = team.Name;
        existing.City = team.City;
        existing.Stadium = team.Stadium;
        existing.LogoUrl = team.LogoUrl;
        existing.FoundedDate = team.FoundedDate;

        await _teamRepository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var exists = await _teamRepository.ExistsAsync(id);
        if (!exists)
            throw new KeyNotFoundException($"No se encontró el equipo con ID {id}");

        await _teamRepository.DeleteAsync(id);
    }
}
