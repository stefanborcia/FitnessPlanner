
namespace FitnessPlanner.Domain.Entities
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = new();

        public string? UserId { get; set; }
    }
}
