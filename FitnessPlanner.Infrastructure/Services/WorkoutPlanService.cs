using AutoMapper;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Infrastructure.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IMapper _mapper;

        public WorkoutPlanService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType)
        {
            var plan = new WorkoutPlan
            {
                Id = Guid.NewGuid(),
                Name = $"{goal} Plan for {bodyType}",
                Exercises = new List<Exercise>()
            };

            if (goal == FitnessGoal.BuildMuscle)
            {
                plan.Exercises.Add(new Exercise { Name = "Bench Press", Reps = 10, Sets = 4 });
                plan.Exercises.Add(new Exercise { Name = "Deadlift", Reps = 8, Sets = 4 });
            }
            else if (goal == FitnessGoal.LoseWeight)
            {
                plan.Exercises.Add(new Exercise { Name = "Jump Rope", Reps = 100, Sets = 3 });
                plan.Exercises.Add(new Exercise { Name = "Burpees", Reps = 15, Sets = 3 });
            }
            else if (goal == FitnessGoal.Tone)
            {
                plan.Exercises.Add(new Exercise { Name = "Planks", Reps = 60, Sets = 3 });
                plan.Exercises.Add(new Exercise { Name = "Bodyweight Squats", Reps = 20, Sets = 3 });
            }

            return _mapper.Map<WorkoutPlanDto>(plan);
        }
    }
}
