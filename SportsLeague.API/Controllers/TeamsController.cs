using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;

namespace SportsLeague.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly IGenericRepository<Team> _repository;

    public TeamsController(IGenericRepository<Team> repository)
    {
        _repository = repository;
    }

    // GET: api/Teams (Obtener todos los equipos)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
    {
        var teams = await _repository.GetAllAsync();
        return Ok(teams);
    }

    // POST: api/Teams (Crear un nuevo equipo)
    [HttpPost]
    public async Task<ActionResult<Team>> CreateTeam(Team team)
    {
        await _repository.AddAsync(team);
        await _repository.SaveAsync();
        return Ok(team);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var team = await _repository.GetByIdAsync(id);

        // Si no existe el equipo con ese ID, avisamos
        if (team == null) return NotFound();

        _repository.Delete(team);
        await _repository.SaveAsync();

        return NoContent(); // Código 204: Borrado con éxito
    }
    
}