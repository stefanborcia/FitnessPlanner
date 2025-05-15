using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.Application.Interfaces
{
    public interface IWorkoutPlanService
    {
        WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType);
        Task<WorkoutPlanDto> GenerateAndSaveWorkoutPlanAsync(PlanRequestDto request, string userId);
        Task<List<WorkoutPlanDto>> GetAllPlansAsync();
        Task<WorkoutPlanDto?> GetPlanByIdAsync(int id);
        Task<bool> UpdatePlanAsync(WorkoutPlanDto plan);
        Task<bool> DeletePlanAsync(int id);
    }
}
