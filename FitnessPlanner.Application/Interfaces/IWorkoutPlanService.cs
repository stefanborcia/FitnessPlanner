using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.Application.Interfaces
{
    public interface IWorkoutPlanService
    {
        WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType);
        Task<string> GenerateAndSaveWorkoutPlanAsync(PlanRequestDto request);
    }
}
