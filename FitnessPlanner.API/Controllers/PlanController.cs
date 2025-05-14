using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
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

        // CREATE
        [HttpPost]
        public async Task<IActionResult> SaveWorkoutPlan([FromBody] PlanRequestDto request)
        {
            try
            {
                var fakeUserId = Guid.Parse("1"); // Replace later
                var result = await _workoutService.GenerateAndSaveWorkoutPlanAsync(request, fakeUserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // READ all
        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await _workoutService.GetAllPlansAsync();
            return Ok(plans);
        }

        // READ by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(Guid id)
        {
            var plan = await _workoutService.GetPlanByIdAsync(id);
            if (plan == null) return NotFound();
            return Ok(plan);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlan(Guid id, [FromBody] WorkoutPlanDto updatedPlan)
        {
            if (id != updatedPlan.Id) return BadRequest("ID mismatch");

            var result = await _workoutService.UpdatePlanAsync(updatedPlan);
            if (!result) return NotFound();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(Guid id)
        {
            var result = await _workoutService.DeletePlanAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
