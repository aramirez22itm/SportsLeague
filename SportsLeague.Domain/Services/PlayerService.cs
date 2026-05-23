using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Player>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Player?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task<bool> CreateAsync(Player entity)
    {
        await _repository.CreateAsync(entity);
       
        return true;
    }

    public async Task<bool> UpdateAsync(Player entity)
    {
        await _repository.UpdateAsync(entity);
        
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return false;

        await _repository.DeleteAsync(id);
        
        return true;
    }
}
