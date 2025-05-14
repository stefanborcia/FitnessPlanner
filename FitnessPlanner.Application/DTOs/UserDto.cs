
namespace FitnessPlanner.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Goal { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
    }
}
