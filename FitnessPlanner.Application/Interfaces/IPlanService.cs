using FitnessPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Application.Interfaces
{
    public interface IPlanService
    {
        Task<List<DayPlan>> GetWeeklyPlanAsync(string userId);
        Task AddOrUpdateDayPlanAsync(DayPlan plan);
        Task<bool> DeleteDayPlanAsync(int id);
    }
}
