using SportsLeague.Domain.Services;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Helpers;

namespace SportsLeague.Domain.Interfaces.Services;

    public interface IMatchEventService
    {
        Task<Goal> AddGoalAsync(int matchId, int playerId, int minute, GoalType type);
        Task<Card> AddCardAsync(int matchId, int playerId, int minute, CardType type);
        Task<MatchResult> AddMatchResultAsync(int matchId, int homeGoals, int awayGoals, string? observations);
    }

