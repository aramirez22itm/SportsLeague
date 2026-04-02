using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.DTOs.Request;

[ApiController]
[Route("api/[controller]")]
public class TournamentSponsorsController : ControllerBase
{
    // Aquí podrías poner el POST para crear la relación N:M
    [HttpPost]
    public IActionResult AssignSponsor(TournamentSponsorRequestDTO request)
    {
        return Ok("Vinculación exitosa (Simulada)");
    }
}
