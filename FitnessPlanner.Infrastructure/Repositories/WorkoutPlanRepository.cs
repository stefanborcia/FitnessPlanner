using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Infrastructure.Data;

namespace FitnessPlanner.Infrastructure.Repositories
{
    public class WorkoutPlanRepository : GenericRepository<WorkoutPlan>, IWorkoutPlanRepository
    {
        public WorkoutPlanRepository(AppDbContext context) : base(context) { }

        //TODO
    }
}
