using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;



namespace SportsLeague.Domain.Services;

public class MatchService : IMatchService
{
    public Task<Match> CreateAsync(Match match)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Match>> GetAllByTournamentAsync(int tournamentId)
    {
        throw new NotImplementedException();
    }

    public Task<Match?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Match match)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStatusAsync(int id, MatchStatus newStatus)
    {
        throw new NotImplementedException();
    }
}
