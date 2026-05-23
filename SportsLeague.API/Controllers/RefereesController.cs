using SportsLeague.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using System;



namespace SportsLeague.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereesController : ControllerBase
    {
        private readonly IRefereeService _refereeService;

        public RefereesController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _refereeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var referee = await _refereeService.GetByIdAsync(id);
            if (referee is null) return NotFound();
            return Ok(referee);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Referee referee)
        {
            referee.CreatedAt = DateTime.UtcNow;
            referee.UpdatedAt = DateTime.UtcNow;

            await _refereeService.CreateAsync(referee);
            return CreatedAtAction(nameof(Get), new { id = referee.Id }, referee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Referee referee)
        {
            if (id != referee.Id) return BadRequest();

            var existing = await _refereeService.GetByIdAsync(id);
            if (existing is null) return NotFound();

            existing.FirstName = referee.FirstName;
            existing.LastName = referee.LastName;
            existing.Nationality = referee.Nationality;
            existing.UpdatedAt = DateTime.UtcNow;

            await _refereeService.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _refereeService.GetByIdAsync(id);
            if (existing is null) return NotFound();

            await _refereeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
