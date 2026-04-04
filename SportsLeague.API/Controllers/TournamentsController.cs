using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class TournamentsController : ControllerBase
{
    private readonly IGenericRepository<Tournament> _repo;
    public TournamentsController(IGenericRepository<Tournament> repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Tournament Tournament)
    {
        await _repo.AddAsync(Tournament);
        await _repo.SaveAsync();
        return Ok(Tournament);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tournament tournament)
    {
        if (id != tournament.Id) return BadRequest();
        _repo.Update(tournament);
        await _repo.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        _repo.Delete(entity);
        await _repo.SaveAsync();
        return NoContent();
    }
}