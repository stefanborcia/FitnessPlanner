using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/dayplans")]
    [ApiController]
    public class DayPlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public DayPlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateDay([FromBody] DayPlan plan)
        {
            await _planService.AddOrUpdateDayPlanAsync(plan);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            await _planService.DeleteDayPlanAsync(id);
            return NoContent();
        }

        [HttpGet("week")]
        public async Task<IActionResult> GetWeeklyPlanForDate([FromQuery] string startDate, [FromQuery] string userId)
        {
            if (!DateTime.TryParse(startDate, out var start))
            {
                return BadRequest("Invalid startDate format.");
            }

            var end = start.AddDays(6);

            var allPlans = await _planService.GetWeeklyPlanAsync(userId);

            var weeklyPlan = allPlans
                .Where(p => DateTime.TryParse(p.Date, out var date) && date >= start && date <= end)
                .ToList();

            return Ok(weeklyPlan);
        }
    }
}
