using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Interfaces.Repositories;


namespace SportsLeague.DataAccess.Repositories;

public class MatchResultRepository : GenericRepository<MatchResult>, IMatchResultRepository
{
    private readonly LeagueDbContext _context;

    public MatchResultRepository(LeagueDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<MatchResult?> GetByMatchIdAsync(int matchId)
    {
        return await _context.MatchResults
            .FirstOrDefaultAsync(mr => mr.MatchId == matchId);
    }
}
