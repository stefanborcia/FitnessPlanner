using FitnessPlanner.Domain.Entities;

namespace FitnessPlanner.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<bool> SaveChangesAsync();
    }
}
