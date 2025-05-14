using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.Application.Interfaces
{
    public interface IWorkoutPlanService
    {
        WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType);
        Task<WorkoutPlanDto> GenerateAndSaveWorkoutPlanAsync(PlanRequestDto request, Guid userId);
        Task<List<WorkoutPlanDto>> GetAllPlansAsync();
        Task<WorkoutPlanDto?> GetPlanByIdAsync(Guid id);
        Task<bool> UpdatePlanAsync(WorkoutPlanDto plan);
        Task<bool> DeletePlanAsync(Guid id);
    }
}
