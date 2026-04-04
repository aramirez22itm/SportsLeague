using AutoMapper;
using SportsLeague.Domain.DTOs;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.DTOs.Response;
using SportsLeague.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()

    {
        // Mapeos para Player
        CreateMap<Player, PlayerResponseDTO>();
        CreateMap<PlayerRequestDTO, Player>();

        // Mapeos para Referee
        CreateMap<Referee, RefereeResponseDTO>();
        CreateMap<RefereeRequestDTO, Referee>();

        // Mapeos para Tournament
        CreateMap<Tournament, TournamentResponseDTO>();
        CreateMap<TournamentRequestDTO, Tournament>();


        // Esto le dice: "Puedes convertir un Team en un TeamDto automáticamente"
        CreateMap<Team, TeamResponseDTO>().ReverseMap();
        CreateMap<TeamRequestDTO, Team>().ReverseMap();

        // Mapeos para Sponsor 
        CreateMap<Sponsor, SponsorResponseDTO>(); // De Entidad a Respuesta
        CreateMap<SponsorRequestDTO, Sponsor>(); // De Solicitud a Entidad

        // Mapeos para TournamentSponsor
        CreateMap<TournamentSponsor, TournamentSponsorResponseDTO>().ReverseMap();
        CreateMap<TournamentSponsorRequestDTO, TournamentSponsor>().ReverseMap();

    }
}