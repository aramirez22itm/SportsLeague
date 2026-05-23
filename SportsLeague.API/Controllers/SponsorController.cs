using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.API.DTOs.Request;
using SportsLeague.API.DTOs.Response;
using SportsLeague.Domain.DTOs.Request;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Services;
using SportsLeague.Domain.Services;
using System;



namespace SportsLeague.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SponsorController : ControllerBase
{
    private readonly ISponsorService _service;
    private readonly IMapper _mapper;
    public SponsorController(ISponsorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SponsorRequestDTO request)
    {
        try
        {
            var sponsor = _mapper.Map<Sponsor>(request);
            await _service.CreateAsync(sponsor);
            return CreatedAtAction(nameof(GetById), new { id = sponsor.Id }, sponsor);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message); // Aquí cae si el nombre está duplicado
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)

    {
        var response = await _service.GetByIdAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [HttpGet] // LISTAR TODOS
    public async Task<IActionResult> GetAll()
    {
        var sponsors = await _service.GetAllAsync(); // Debes crearlo en el Service
        return Ok(sponsors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        
        return NoContent(); // Retorna 204 si todo salió bien
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Sponsor sponsor)
    {
        if (id != sponsor.Id) return BadRequest();

        // Aquí usamos el servicio que declaraste arriba
        await _service.UpdateAsync(id, sponsor);
       
        return NoContent();
    }
}
