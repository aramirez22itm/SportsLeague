using AutoMapper;
using SportsLeague.Domain.DTOs;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.DTOs.Response;
using SportsLeague.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Esto le dice: "Puedes convertir un Team en un TeamDto automáticamente"
        CreateMap<Team, TeamDto>().ReverseMap();

        // Mapeos para Sponsor 
        CreateMap<Sponsor, SponsorResponseDTO>(); // De Entidad a Respuesta
        CreateMap<SponsorRequestDTO, Sponsor>(); // De Solicitud a Entidad

        // Mapeos para TournamentSponsor
        // CreateMap<TournamentSponsor, TournamentSponsorResponseDTO>().ReverseMap();
        // CreateMap<TournamentSponsorRequestDTO, TournamentSponsor>().ReverseMap();

    }
}