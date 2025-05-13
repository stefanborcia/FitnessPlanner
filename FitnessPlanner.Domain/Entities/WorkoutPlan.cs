
namespace FitnessPlanner.Domain.Entities
{
    public class WorkoutPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = new();
    }
}
