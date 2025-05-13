using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Application.Interfaces
{
    public interface IWorkoutPlanService
    {
        WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType);
    }
}
