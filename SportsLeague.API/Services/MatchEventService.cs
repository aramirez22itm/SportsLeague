using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Helpers;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Services
{
    public class MatchEventService : IMatchEventService
    {
        private readonly MatchValidationHelper _validator;
        private readonly IGoalRepository _goalRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IMatchResultRepository _matchResultRepository;

        public MatchEventService(
            MatchValidationHelper validator,
            IGoalRepository goalRepository,
            ICardRepository cardRepository,
            IMatchResultRepository matchResultRepository)
        {
            _validator = validator;
            _goalRepository = goalRepository;
            _cardRepository = cardRepository;
            _matchResultRepository = matchResultRepository;
        }

        public async Task<Goal> AddGoalAsync(int matchId, int playerId, int minute, GoalType type)
        {
            var match = await _validator.ValidateMatchExistsAsync(matchId);
            _validator.ValidateMatchIsInProgress(match);

            var player = await _validator.ValidatePlayerExistsAsync(playerId);
            _validator.ValidatePlayerBelongsToMatch(player, match);
            _validator.ValidateMinute(minute);

            var goal = new Goal
            {
                MatchId = matchId,
                PlayerId = playerId,
                Minute = minute,
                Type = type
            };

            return await _goalRepository.CreateAsync(goal);
        }

        public async Task<Card> AddCardAsync(int matchId, int playerId, int minute, CardType type)
        {
            var match = await _validator.ValidateMatchExistsAsync(matchId);
            _validator.ValidateMatchIsInProgress(match);

            var player = await _validator.ValidatePlayerExistsAsync(playerId);
            _validator.ValidatePlayerBelongsToMatch(player, match);
            _validator.ValidateMinute(minute);

            var card = new Card
            {
                MatchId = matchId,
                PlayerId = playerId,
                Minute = minute,
                Type = type
            };

            return await _cardRepository.CreateAsync(card);
        }

        public async Task<MatchResult> AddMatchResultAsync(int matchId, int homeGoals, int awayGoals, string? observations)
        {
            var match = await _validator.ValidateMatchExistsAsync(matchId);
            _validator.ValidateMatchIsInProgress(match);

            await _validator.ValidateMatchHasNoResultAsync(matchId);

            var result = new MatchResult
            {
                MatchId = matchId,
                HomeGoals = homeGoals,
                AwayGoals = awayGoals,
                Observations = observations
            };

            return await _matchResultRepository.CreateAsync(result);
        }
    }
}
