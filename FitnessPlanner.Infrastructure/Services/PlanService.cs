using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.Infrastructure.Services
{
    public class PlanService : IPlanService
    {
        private readonly AppDbContext _context;

        public PlanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DayPlan>> GetWeeklyPlanAsync(string userId)
        {
            // Fetch user's weekly plan from the database
            var userPlan = _context.DayPlans
                .Where(dp => dp.UserId == userId)
                .ToList();

            if (!userPlan.Any())
            {
                userPlan = GenerateDefaultPlan(userId);
                // Save to DB
                _context.DayPlans.AddRange(userPlan);
                _context.SaveChanges();
            }

            return userPlan;
        }

        //private List<DayPlan> GenerateDefaultPlan(string userId)
        //{

        //    return
        //[
        //    new DayPlan {
        //        Day = "Monday",
        //        Workout = "Chest + Triceps",
        //        Meals = new List < string > { "Oats + Eggs", "Grilled Chicken Salad", "Salmon + Veggies" },
        //        HydrationTimes = new List < string > { "9am", "12pm", "3pm" }
        //    },
        //    new DayPlan {
        //        Day = "Tuesday",
        //        Workout = "Back + Biceps",
        //        Meals = new List < string > { "Greek Yogurt + Berries", "Tuna Salad", "Steak + Broccoli" },
        //        HydrationTimes = new List < string > { "9am", "12pm", "3pm" }
        //    },
        //    new DayPlan {
        //        Day = "Wednesday",
        //        Workout = "Legs + Abs",
        //        Meals = new List < string > { "Protein Shake", "Chicken + Quinoa", "Fish + Asparagus" },
        //        HydrationTimes = new List < string > { "9am", "12pm", "3pm" }
        //    },
        //    new DayPlan {
        //        Day = "Thursday",
        //        Workout = "Shoulders + Abs",
        //        Meals =     new List < string > { "Oatmeal + Banana", "Turkey Wrap", "Shrimp + Veggies" },
        //        HydrationTimes = new List < string > { "9am", "12pm", "3pm" }
        //    },
        //    new DayPlan {
        //        Day = "Friday",
        //        Workout = "Full Body",
        //        Meals = new List < string > { "Smoothie", "Chicken + Rice", "Pasta + Meatballs" },
        //        HydrationTimes = new List < string > { "9am", "12pm", "3pm" }
        //    },
        //    new DayPlan {
        //        Day = "Saturday",
        //        Workout = "Cardio + Stretching",
        //        Meals = new List < string > { "Eggs + Avocado", "Salad + Quinoa", "Grilled Fish" },
        //        HydrationTimes = new List < string > { "9am", "12pm", "3pm" }
        //    },
        //    new DayPlan {
        //        Day = "Sunday",
        //        Workout = "Rest Day",
        //        Meals = new List<string> {"Pancakes + Fruit", "Chicken + Veggies", "Steak + Salad" },
        //        HydrationTimes = new List<string> {"9am", "12pm", "3pm" }
        //    }
        //];
        //}

        private List<DayPlan> GenerateDefaultPlan(string userId)
        {
            var startOfWeek = DateTime.Today;
            int diff = startOfWeek.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) diff += 7;
            startOfWeek = startOfWeek.AddDays(-diff); // Go back to Monday

            var days = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var plans = new List<DayPlan>();

            for (int i = 0; i < 7; i++)
            {
                plans.Add(new DayPlan
                {
                    UserId = userId,
                    Day = days[i],
                    Date = startOfWeek.AddDays(i).ToString("yyyy-MM-dd"),
                    Workout = i == 6 ? "Rest Day" : $"Workout Day {i + 1}",
                    Meals = new List<string> { "Meal 1", "Meal 2", "Meal 3" },
                    HydrationTimes = new List<string> { "9am", "12pm", "3pm" }
                });
            }

            return plans;
        }
        public async Task AddOrUpdateDayPlanAsync(DayPlan plan)
        {
            var existing = await _context.DayPlans
                .FirstOrDefaultAsync(p => p.Id == plan.Id && p.UserId == plan.UserId);

            if (existing != null)
            {
                existing.Day = plan.Day;
                existing.Workout = plan.Workout;
                existing.Meals = plan.Meals;
                existing.HydrationTimes = plan.HydrationTimes;
            }
            else
            {
                _context.DayPlans.Add(plan);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDayPlanAsync(int id)
        {
            var plan = await _context.DayPlans.FindAsync(id);
            if (plan == null) return false;

            _context.DayPlans.Remove(plan);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
