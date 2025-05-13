

namespace FitnessPlanner.Domain.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
