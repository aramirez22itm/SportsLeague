using AutoMapper;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Esto le dice: "Puedes convertir un Team en un TeamDto automáticamente"
        CreateMap<Team, TeamDto>().ReverseMap();
    }
}