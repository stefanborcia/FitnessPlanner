using FitnessPlanner.Domain.Entities;

namespace FitnessPlanner.Application.Interfaces.Repositories
{
    public interface IWorkoutPlanRepository : IGenericRepository<WorkoutPlan>
    {
        List<WorkoutPlan> GetByUserId(string userId);
    }
}
