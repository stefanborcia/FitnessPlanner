using AutoMapper;
using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Domain.Enums;
using FitnessPlanner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.Infrastructure.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public WorkoutPlanService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType)
        {
            var plan = CreateWorkoutPlan(goal, bodyType, "Auto Plan");
            return _mapper.Map<WorkoutPlanDto>(plan);
        }

        public async Task<string> GenerateAndSaveWorkoutPlanAsync(PlanRequestDto request)
        {
            // Validate user exists
            var userExists = await _context.Users.AnyAsync(u => u.Id == request.UserId);
            if (!userExists)
                throw new Exception("User does not exist");

            var plan = CreateWorkoutPlan(request.Goal, request.BodyType, request.Name);
            plan.UserId = request.UserId;

            await _context.WorkoutPlans.AddAsync(plan);
            await _context.SaveChangesAsync();

            return $"Plan '{plan.Name}' saved successfully!";
        }

        private WorkoutPlan CreateWorkoutPlan(FitnessGoal goal, BodyType bodyType, string name)
        {
            var plan = new WorkoutPlan
            {
                Id = Guid.NewGuid(),
                Name = name,
                Exercises = new List<Exercise>()
            };

            switch (goal)
            {
                case FitnessGoal.BuildMuscle:
                    plan.Exercises.Add(new Exercise { Name = "Bench Press", Reps = 10, Sets = 4 });
                    plan.Exercises.Add(new Exercise { Name = "Deadlift", Reps = 8, Sets = 4 });
                    break;
                case FitnessGoal.LoseWeight:
                    plan.Exercises.Add(new Exercise { Name = "Jump Rope", Reps = 100, Sets = 3 });
                    plan.Exercises.Add(new Exercise { Name = "Burpees", Reps = 15, Sets = 3 });
                    break;
                case FitnessGoal.Tone:
                    plan.Exercises.Add(new Exercise { Name = "Planks", Reps = 60, Sets = 3 });
                    plan.Exercises.Add(new Exercise { Name = "Bodyweight Squats", Reps = 20, Sets = 3 });
                    break;
            }

            return plan;
        }
    }
}
