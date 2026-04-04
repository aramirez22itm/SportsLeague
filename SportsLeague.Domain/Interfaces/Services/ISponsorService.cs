using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.DTOs.Response;
using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Services;

public interface ISponsorService
{
    Task<IEnumerable<SponsorResponseDTO>> GetAllAsync();
    Task<SponsorResponseDTO> CreateAsync(SponsorRequestDTO request);
    Task<SponsorResponseDTO?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, Sponsor sponsor);
    Task<bool> DeleteAsync(int id);
}
