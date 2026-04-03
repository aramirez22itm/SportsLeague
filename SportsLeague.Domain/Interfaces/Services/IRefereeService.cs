using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Services
{
    public interface IRefereeService
    {
        Task<IEnumerable<Referee>> GetAllAsync();
        Task<Referee> GetByIdAsync(int id);
        Task<bool> CreateAsync(Referee entity);
        Task<bool> UpdateAsync(Referee entity);
        Task<bool> DeleteAsync(int id);
    }
}