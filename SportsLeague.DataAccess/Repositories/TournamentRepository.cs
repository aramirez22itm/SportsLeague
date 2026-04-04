using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories;

public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
{
    public TournamentRepository(ApplicationDbContext context) : base(context) { }
}