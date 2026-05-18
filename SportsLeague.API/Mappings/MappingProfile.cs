using AutoMapper;
using SportsLeague.API.DTOs.Request;
using SportsLeague.API.DTOs.Response;
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

        // Mapeos para Match
        CreateMap<MatchRequestDTO, Match>();

        CreateMap<Match, MatchResponseDTO>()
            .ForMember(dest => dest.TournamentName, opt => opt.MapFrom(src => src.Tournament.Name))
            .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.Name))
            .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.Name))
            .ForMember(dest => dest.RefereeFullName, opt => opt.MapFrom(src => src.Referee.FirstName + " " + src.Referee.LastName));

    }
}