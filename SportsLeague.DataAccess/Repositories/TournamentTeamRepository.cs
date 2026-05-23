using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;


namespace SportsLeague.DataAccess.Repositories
{
    public class TournamentTeamRepository : GenericRepository<TournamentTeam>, ITournamentTeamRepository
    {
        private readonly LeagueDbContext _context;

        public TournamentTeamRepository(LeagueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TournamentTeam?> GetByTournamentAndTeamAsync(int tournamentId, int teamId)
        {
            return await _context.TournamentTeams
                .FirstOrDefaultAsync(tt => tt.TournamentId == tournamentId && tt.TeamId == teamId);
        }

        public async Task<IEnumerable<TournamentTeam>> GetByTournamentAsync(int tournamentId)
        {
            return await _context.TournamentTeams
                .Where(tt => tt.TournamentId == tournamentId)
                .Include(tt => tt.Team)
                .ToListAsync();
        }
    }
}
