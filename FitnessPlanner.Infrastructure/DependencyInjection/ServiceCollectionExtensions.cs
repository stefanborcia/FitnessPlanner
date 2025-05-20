using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Domain.Entities;
using FitnessPlanner.Infrastructure.Data;
using FitnessPlanner.Infrastructure.Repositories;
using FitnessPlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessPlanner.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // EF Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IWorkoutPlanRepository, WorkoutPlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services
            services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPlanService, PlanService>();

            // Auth utilities
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


            return services;
        }
    }
}
