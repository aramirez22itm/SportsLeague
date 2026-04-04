using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IGenericRepository<Player> _repo;
    public PlayersController(IGenericRepository<Player> repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Player player)
    {
        await _repo.AddAsync(player);
        await _repo.SaveAsync();
        return Ok(player);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Player player)
    {
        if (id != player.Id) return BadRequest();

        _repo.Update(player);
        await _repo.SaveAsync();

        return NoContent();
    }
}