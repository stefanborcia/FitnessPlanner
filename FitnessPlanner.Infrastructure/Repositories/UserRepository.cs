using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
