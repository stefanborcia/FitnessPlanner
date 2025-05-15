using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public FitnessGoal Goal { get; set; }
        public BodyType BodyType { get; set; }
    }
}
