using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;
using System;


namespace SportsLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _playerService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player is null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Player player)
        {
            player.CreatedAt = DateTime.UtcNow;
            player.UpdatedAt = DateTime.UtcNow;

            await _playerService.CreateAsync(player);
            return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Player player)
        {
            if (id != player.Id) return BadRequest();

            var existing = await _playerService.GetByIdAsync(id);
            if (existing is null) return NotFound();

            existing.FirstName = player.FirstName;
            existing.LastName = player.LastName;
            existing.BirthDate = player.BirthDate;
            existing.Position = player.Position;
            existing.TeamId = player.TeamId;
            existing.UpdatedAt = DateTime.UtcNow;

            await _playerService.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _playerService.GetByIdAsync(id);
            if (existing is null) return NotFound();

            await _playerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
