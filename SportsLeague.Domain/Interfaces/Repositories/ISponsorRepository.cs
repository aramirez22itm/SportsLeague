using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Repositories;

public interface ISponsorRepository : IGenericRepository<Sponsor>
{
    // Este método es el que usas en el Service para el nombre duplicado
    Task<bool> ExistsByNameAsync(string name);
}