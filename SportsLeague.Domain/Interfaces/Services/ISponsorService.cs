using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.DTOs.Response;

namespace SportsLeague.Domain.Interfaces.Services;

public interface ISponsorService
{
    Task<SponsorResponseDTO> CreateAsync(SponsorRequestDTO request);
    Task<SponsorResponseDTO?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
