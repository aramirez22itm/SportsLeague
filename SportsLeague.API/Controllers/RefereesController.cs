using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class RefereesController : ControllerBase
{
    private readonly IGenericRepository<Referee> _repo;
    public RefereesController(IGenericRepository<Referee> repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Referee Referee)
    {
        await _repo.AddAsync(Referee);
        await _repo.SaveAsync();
        return Ok(Referee);
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
    public async Task<IActionResult> Put(int id, Referee referee)
    {
        if (id != referee.Id) return BadRequest();

        _repo.Update(referee);
        await _repo.SaveAsync();

        return NoContent();
    }
}