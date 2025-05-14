using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IWorkoutPlanService _workoutService;

        public PlanController(IWorkoutPlanService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost("save-workout")]
        public async Task<IActionResult> SaveWorkoutPlan([FromBody] PlanRequestDto request)
        {
            try
            {
                var message = await _workoutService.GenerateAndSaveWorkoutPlanAsync(request);
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


    }
}
