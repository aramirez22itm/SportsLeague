using AutoMapper;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services;

public class SponsorService : ISponsorService
{
    public Task<Sponsor> CreateAsync(Sponsor sponsor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Sponsor>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Sponsor?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Sponsor sponsor)
    {
        throw new NotImplementedException();
    }
}