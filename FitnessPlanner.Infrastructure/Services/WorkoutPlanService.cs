using AutoMapper;
using FitnessPlanner.API.DTOs;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.Infrastructure.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IWorkoutPlanRepository _repository;
        private readonly IMapper _mapper;

        public WorkoutPlanService(IWorkoutPlanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public WorkoutPlanDto GenerateWorkoutPlan(FitnessGoal goal, BodyType bodyType)
        {
            var plan = new WorkoutPlan
            {
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

        public async Task<WorkoutPlanDto> GenerateAndSaveWorkoutPlanAsync(PlanRequestDto request, string userId)
        {
            var plan = new WorkoutPlan
            {
                Name = $"{request.Goal} Plan for {request.BodyType}",
                UserId = userId,
                Exercises = new List<Exercise>()
            };

            if (request.Goal == FitnessGoal.BuildMuscle)
            {
                plan.Exercises.Add(new Exercise { Name = "Bench Press", Reps = 10, Sets = 4 });
                plan.Exercises.Add(new Exercise { Name = "Deadlift", Reps = 8, Sets = 4 });
            }
            else if (request.Goal == FitnessGoal.LoseWeight)
            {
                plan.Exercises.Add(new Exercise { Name = "Jump Rope", Reps = 100, Sets = 3 });
                plan.Exercises.Add(new Exercise { Name = "Burpees", Reps = 15, Sets = 3 });
            }
            else if (request.Goal == FitnessGoal.Tone)
            {
                plan.Exercises.Add(new Exercise { Name = "Planks", Reps = 60, Sets = 3 });
                plan.Exercises.Add(new Exercise { Name = "Bodyweight Squats", Reps = 20, Sets = 3 });
            }

            await _repository.AddAsync(plan);
            await _repository.SaveChangesAsync();

            return _mapper.Map<WorkoutPlanDto>(plan);
        }
        // ✅ GET ALL
        public async Task<List<WorkoutPlanDto>> GetAllPlansAsync()
        {
            var plans = await _repository.GetAllAsync();
            return _mapper.Map<List<WorkoutPlanDto>>(plans);
        }

        // ✅ GET BY ID
        public async Task<WorkoutPlanDto?> GetPlanByIdAsync(int id)
        {
            var plan = await _repository.GetByIdAsync(id);
            return plan == null ? null : _mapper.Map<WorkoutPlanDto>(plan);
        }

        // ✅ UPDATE
        public async Task<bool> UpdatePlanAsync(WorkoutPlanDto planDto)
        {
            var existingPlan = await _repository.GetByIdAsync(planDto.Id);
            if (existingPlan == null) return false;

            // Update fields (you can improve with AutoMapper if needed)
            existingPlan.Name = planDto.Name;
            // optionally update exercises or other properties

            _repository.Update(existingPlan);
            await _repository.SaveChangesAsync();
            return true;
        }

        // ✅ DELETE
        public async Task<bool> DeletePlanAsync(int id)
        {
            var plan = await _repository.GetByIdAsync(id);
            if (plan == null) return false;

            _repository.Delete(plan);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
