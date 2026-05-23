using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.API.DTOs.Request;
using SportsLeague.API.DTOs.Response;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Services;
using System;



namespace SportsLeague.API.Controllers
{
    [ApiController]
    [Route("api/matches/{matchId}/events")]
    public class MatchEventController : ControllerBase
    {
        private readonly IMatchEventService _eventService;
        private readonly IMapper _mapper;

        public MatchEventController(IMatchEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost("goals")]
        public async Task<IActionResult> AddGoal(int matchId, GoalRequestDTO dto)
        {
            try
            {
                var goal = await _eventService.AddGoalAsync(matchId, dto.PlayerId, dto.Minute, dto.Type);
                return Ok(goal);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("cards")]
        public async Task<IActionResult> AddCard(int matchId, CardRequestDTO dto)
        {
            try
            {
                var card = await _eventService.AddCardAsync(matchId, dto.PlayerId, dto.Minute, dto.Type);
                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("result")]
        public async Task<IActionResult> AddResult(int matchId, MatchResultRequestDTO dto)
        {
            try
            {
                var result = await _eventService.AddMatchResultAsync(matchId, dto.HomeGoals, dto.AwayGoals, dto.Observations);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
