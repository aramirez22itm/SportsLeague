using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;
using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(LeagueDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Match>> GetByTournamentAsync(int tournamentId)
        {
            return await _dbSet
                .Where(x => x.TournamentId == tournamentId)
                .OrderBy(x => x.MatchDate)   // ← MatchDay NO EXISTE
                .ToListAsync();
        }

        public async Task<IEnumerable<Match>> GetByTeamAsync(int teamId)
        {
            return await _dbSet
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Where(x => x.HomeTeamId == teamId || x.AwayTeamId == teamId)
                .ToListAsync();
        }

        public async Task<Match?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.Referee)
                .Include(x => x.Goals)
                .Include(x => x.Cards)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Match>> GetByTournamentWithDetailsAsync(int tournamentId)
        {
            return await _dbSet
                .Where(x => x.TournamentId == tournamentId)
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.Referee)
                .Include(x => x.Goals)
                .Include(x => x.Cards)
                .OrderBy(x => x.MatchDate)   // ← MatchDay NO EXISTE
                .ToListAsync();
        }
    }
}
