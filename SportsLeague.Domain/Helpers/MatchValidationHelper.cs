using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.Domain.Helpers
{
    public class MatchValidationHelper
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMatchResultRepository _matchResultRepository;

        public MatchValidationHelper(
            IMatchRepository matchRepository,
            IPlayerRepository playerRepository,
            IMatchResultRepository matchResultRepository)
        {
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
            _matchResultRepository = matchResultRepository;
        }

        public async Task<Match> ValidateMatchExistsAsync(int matchId)
        {
            var match = await _matchRepository.GetByIdWithDetailsAsync(matchId);
            if (match == null)
                throw new KeyNotFoundException($"No se encontró el partido con ID {matchId}");

            return match;
        }

        public void ValidateMatchIsInProgress(Match match)
        {
            if (match.Status != MatchStatus.InProgress)
                throw new InvalidOperationException("Solo se pueden registrar eventos en partidos InProgress");
        }

        public async Task<Player> ValidatePlayerExistsAsync(int playerId)
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            if (player == null)
                throw new KeyNotFoundException($"No se encontró el jugador con ID {playerId}");

            return player;
        }

        public void ValidatePlayerBelongsToMatch(Player player, Match match)
        {
            if (player.TeamId != match.HomeTeamId && player.TeamId != match.AwayTeamId)
                throw new InvalidOperationException("El jugador no pertenece a ninguno de los equipos del partido");
        }

        public void ValidateMinute(int minute)
        {
            if (minute < 1 || minute > 120)
                throw new InvalidOperationException("El minuto debe estar entre 1 y 120");
        }

        public async Task ValidateMatchHasNoResultAsync(int matchId)
        {
            var result = await _matchResultRepository.GetByMatchIdAsync(matchId);
            if (result != null)
                throw new InvalidOperationException("El partido ya tiene un resultado registrado");
        }

        public async Task ValidateMatchHasResultAsync(int matchId)
        {
            var result = await _matchResultRepository.GetByMatchIdAsync(matchId);
            if (result == null)
                throw new InvalidOperationException("El partido no tiene un resultado registrado");
        }
    }
}
