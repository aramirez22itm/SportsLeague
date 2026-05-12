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
        await _repo.CreateAsync(player);
        await _repo.SaveAsync();
        return Ok(player);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null) return NotFound();
        await _repo.DeleteAsync(id);
        await _repo.SaveAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Player player)
    {
        if (id != player.Id) return BadRequest();

        await _repo.UpdateAsync(player);
        await _repo.SaveAsync();

        return NoContent();
    }
}