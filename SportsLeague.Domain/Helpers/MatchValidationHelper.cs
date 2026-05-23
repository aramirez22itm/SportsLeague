using System.Threading.Tasks;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.Domain.Helpers
{
    public class MatchValidationHelper
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IMatchResultRepository _matchResultRepository;

        public MatchValidationHelper(
            IPlayerRepository playerRepository,
            IMatchRepository matchRepository,
            IGoalRepository goalRepository,
            ICardRepository cardRepository,
            IMatchResultRepository matchResultRepository)
        {
            _playerRepository = playerRepository;
            _matchRepository = matchRepository;
            _goalRepository = goalRepository;
            _cardRepository = cardRepository;
            _matchResultRepository = matchResultRepository;
        }

        // Ejemplo de método (puedes completarlo en fases posteriores)
        public Task<bool> ValidatePlayersExistAsync(int homePlayerId, int awayPlayerId)
        {
            return Task.FromResult(true);
        }
    }
}
