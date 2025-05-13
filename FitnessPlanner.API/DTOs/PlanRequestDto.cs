using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.API.DTOs
{
    public class PlanRequestDto
    {
        public FitnessGoal Goal { get; set; }
        public BodyType BodyType { get; set; }
    }
}
