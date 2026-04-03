using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Services
{
    public class PlayerService : IPlayerService // Aquí implementa la interfaz
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Player>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Player> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<bool> CreateAsync(Player entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Player entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _repository.Delete(entity); // El Delete es sincrónico (void)
            await _repository.SaveAsync(); // El Save es asíncrono
            return true;
        }
    }
}