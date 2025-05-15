using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.API.DTOs
{
    public class PlanRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public FitnessGoal Goal { get; set; }
        public BodyType BodyType { get; set; }
        public string? UserId { get; set; } = string.Empty;
    }
}
