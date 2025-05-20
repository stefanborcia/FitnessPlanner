using FitnessPlanner.Domain.Enums;

namespace FitnessPlanner.Application.DTOs
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public FitnessGoal Goal { get; set; }
        public BodyType BodyType { get; set; }
        public SubscriptionType Subscription { get; set; }
    }
}
