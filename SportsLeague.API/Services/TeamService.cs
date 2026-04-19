using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
            => await _teamRepository.GetAllAsync();

        public async Task<Team> GetByIdAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
                throw new KeyNotFoundException("Equipo no encontrado");

            return team;
        }

        public async Task<bool> CreateAsync(Team entity)
        {
            if (await _teamRepository.ExistsByNameAsync(entity.Name))
                throw new InvalidOperationException("Nombre de equipo duplicado");

            return await _teamRepository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(Team entity)
        {
            if (!await _teamRepository.ExistsAsync(entity.Id))
                throw new KeyNotFoundException("Equipo no encontrado");

            return await _teamRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _teamRepository.ExistsAsync(id))
                throw new KeyNotFoundException("Equipo no encontrado");

            return await _teamRepository.DeleteAsync(id);
        }
    }
}
