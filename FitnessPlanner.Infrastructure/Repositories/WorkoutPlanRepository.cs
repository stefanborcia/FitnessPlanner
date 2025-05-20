using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.Infrastructure.Repositories
{
    public class WorkoutPlanRepository(AppDbContext context) : GenericRepository<WorkoutPlan>(context), IWorkoutPlanRepository
    {
        public List<WorkoutPlan> GetByUserId(string userId)
        {
            return _context.WorkoutPlans
                .Include(wp => wp.Exercises)
                .Where(wp => wp.UserId == userId)
                .ToList();
        }
    }
}
