using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/workoutplans")]
    [ApiController]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly IWorkoutPlanService _workoutService;

        public WorkoutPlanController(IWorkoutPlanService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveWorkoutPlan([FromBody] PlanRequestDto request)
        {
            try
            {
                var result = await _workoutService.GenerateAndSaveWorkoutPlanAsync(request, request.UserId!);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await _workoutService.GetAllPlansAsync();
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(int id)
        {
            var plan = await _workoutService.GetPlanByIdAsync(id);
            if (plan == null) return NotFound();
            return Ok(plan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlan(int id, [FromBody] WorkoutPlanDto updatedPlan)
        {
            if (id != updatedPlan.Id) return BadRequest("ID mismatch");

            var result = await _workoutService.UpdatePlanAsync(updatedPlan);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var result = await _workoutService.DeletePlanAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
