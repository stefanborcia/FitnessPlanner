
namespace FitnessPlanner.Application.DTOs
{
    public class WorkoutPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExerciseDto> Exercises { get; set; } = new();
    }
}
