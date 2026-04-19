using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsLeague.Domain.Interfaces.Repositories
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<bool> ExistsByNameAsync(string name);

      
    }

}