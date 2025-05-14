using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Infrastructure.Data;
using FitnessPlanner.Infrastructure.Repositories;
using FitnessPlanner.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessPlanner.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();
            services.AddScoped<IWorkoutPlanRepository, WorkoutPlanRepository>();

            services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
