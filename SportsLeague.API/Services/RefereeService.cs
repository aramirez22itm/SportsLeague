using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Services
{
    public class RefereeService : IRefereeService // Aquí implementa la interfaz
    {
        private readonly IRefereeRepository _repository;

        public RefereeService(IRefereeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Referee>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Referee> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<bool> CreateAsync(Referee entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Referee entity)
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