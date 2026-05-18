using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.API.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITournamentTeamRepository _tournamentTeamRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IRefereeRepository _refereeRepository;

        public MatchService(
            IMatchRepository matchRepository,
            ITournamentRepository tournamentRepository,
            ITournamentTeamRepository tournamentTeamRepository,
            ITeamRepository teamRepository,
            IRefereeRepository refereeRepository)
        {
            _matchRepository = matchRepository;
            _tournamentRepository = tournamentRepository;
            _tournamentTeamRepository = tournamentTeamRepository;
            _teamRepository = teamRepository;
            _refereeRepository = refereeRepository;
        }

        public async Task<IEnumerable<Match>> GetAllByTournamentAsync(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(tournamentId);
            if (tournament == null)
                throw new KeyNotFoundException($"No se encontró el torneo con ID {tournamentId}");

            return await _matchRepository.GetByTournamentWithDetailsAsync(tournamentId);
        }

        public async Task<Match?> GetByIdAsync(int id)
        {
            return await _matchRepository.GetByIdWithDetailsAsync(id);
        }

        public async Task<Match> CreateAsync(Match match)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(match.TournamentId);
            if (tournament == null)
                throw new KeyNotFoundException($"No se encontró el torneo con ID {match.TournamentId}");

            if (tournament.Status != TournamentStatus.InProgress)
                throw new InvalidOperationException("Solo se pueden programar partidos en torneos InProgress");

            if (match.HomeTeamId == match.AwayTeamId)
                throw new InvalidOperationException("Los equipos deben ser diferentes");

            if (!await _teamRepository.ExistsAsync(match.HomeTeamId))
                throw new KeyNotFoundException($"No se encontró el equipo local con ID {match.HomeTeamId}");

            if (!await _teamRepository.ExistsAsync(match.AwayTeamId))
                throw new KeyNotFoundException($"No se encontró el equipo visitante con ID {match.AwayTeamId}");

            if (await _tournamentTeamRepository.GetByTournamentAndTeamAsync(match.TournamentId, match.HomeTeamId) == null)
                throw new InvalidOperationException("El equipo local no está inscrito en el torneo");

            if (await _tournamentTeamRepository.GetByTournamentAndTeamAsync(match.TournamentId, match.AwayTeamId) == null)
                throw new InvalidOperationException("El equipo visitante no está inscrito en el torneo");

            if (!await _refereeRepository.ExistsAsync(match.RefereeId))
                throw new KeyNotFoundException($"No se encontró el árbitro con ID {match.RefereeId}");

            match.Status = MatchStatus.Scheduled;

            return await _matchRepository.CreateAsync(match);
        }

        public async Task UpdateAsync(int id, Match match)
        {
            var existing = await _matchRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"No se encontró el partido con ID {id}");

            if (existing.Status != MatchStatus.Scheduled)
                throw new InvalidOperationException("Solo se pueden editar partidos Scheduled");

            if (match.HomeTeamId == match.AwayTeamId)
                throw new InvalidOperationException("Los equipos deben ser diferentes");

            if (!await _refereeRepository.ExistsAsync(match.RefereeId))
                throw new KeyNotFoundException($"No se encontró el árbitro con ID {match.RefereeId}");

            existing.HomeTeamId = match.HomeTeamId;
            existing.AwayTeamId = match.AwayTeamId;
            existing.RefereeId = match.RefereeId;
            existing.MatchDate = match.MatchDate;
            existing.Venue = match.Venue;
            existing.Matchday = match.Matchday;

            await _matchRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _matchRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"No se encontró el partido con ID {id}");

            if (existing.Status != MatchStatus.Scheduled)
                throw new InvalidOperationException("Solo se pueden eliminar partidos Scheduled");

            await _matchRepository.DeleteAsync(id);
        }

        public async Task UpdateStatusAsync(int id, MatchStatus newStatus)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
                throw new KeyNotFoundException($"No se encontró el partido con ID {id}");

            var valid = (match.Status, newStatus) switch
            {
                (MatchStatus.Scheduled, MatchStatus.InProgress) => true,
                (MatchStatus.InProgress, MatchStatus.Finished) => true,
                (MatchStatus.Scheduled, MatchStatus.Suspended) => true,
                (MatchStatus.InProgress, MatchStatus.Suspended) => true,
                _ => false
            };

            if (!valid)
                throw new InvalidOperationException($"No se puede cambiar de {match.Status} a {newStatus}");

            match.Status = newStatus;

            await _matchRepository.UpdateAsync(match);
        }
    }
}
