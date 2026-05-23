using SportsLeague.Domain.Interfaces.Services;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;



namespace SportsLeague.Domain.Services;

public class MatchEventService : IMatchEventService
{
    private readonly IMatchRepository _matchRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IGoalRepository _goalRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IMatchResultRepository _matchResultRepository;

    public MatchEventService(
        IMatchRepository matchRepository,
        IPlayerRepository playerRepository,
        IGoalRepository goalRepository,
        ICardRepository cardRepository,
        IMatchResultRepository matchResultRepository)
    {
        _matchRepository = matchRepository;
        _playerRepository = playerRepository;
        _goalRepository = goalRepository;
        _cardRepository = cardRepository;
        _matchResultRepository = matchResultRepository;
    }

    public async Task<Goal> AddGoalAsync(int matchId, int playerId, int minute, GoalType type)
    {
        var match = await _matchRepository.GetByIdAsync(matchId)
                     ?? throw new Exception("Match not found");

        var player = await _playerRepository.GetByIdAsync(playerId)
                      ?? throw new Exception("Player not found");

        var goal = new Goal
        {
            MatchId = matchId,
            PlayerId = playerId,
            Minute = minute,
            Type = type
        };

        await _goalRepository.CreateAsync(goal);
        

        return goal;
    }

    public async Task<Card> AddCardAsync(int matchId, int playerId, int minute, CardType type)
    {
        var match = await _matchRepository.GetByIdAsync(matchId)
                     ?? throw new Exception("Match not found");

        var player = await _playerRepository.GetByIdAsync(playerId)
                      ?? throw new Exception("Player not found");

        var card = new Card
        {
            MatchId = matchId,
            PlayerId = playerId,
            Minute = minute,
            Type = type
        };

        await _cardRepository.CreateAsync(card);
        

        return card;
    }

    public async Task<MatchResult> AddMatchResultAsync(int matchId, int homeGoals, int awayGoals, string? observations)
    {
        var match = await _matchRepository.GetByIdAsync(matchId)
                     ?? throw new Exception("Match not found");

        var result = new MatchResult
        {
            MatchId = matchId,
            HomeGoals = homeGoals,
            AwayGoals = awayGoals,
            Observations = observations,
            CreatedAt = DateTime.UtcNow
        };

        await _matchResultRepository.CreateAsync(result);
       

        return result;
    }
}
