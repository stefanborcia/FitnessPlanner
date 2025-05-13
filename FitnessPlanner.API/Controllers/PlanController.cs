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

        [HttpPost("workout")]
        public IActionResult GenerateWorkoutPlan([FromBody] PlanRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Request object is null");
            }

            var plan = _workoutService.GenerateWorkoutPlan(request.Goal, request.BodyType);
            return Ok(plan);
        }

    }
}
