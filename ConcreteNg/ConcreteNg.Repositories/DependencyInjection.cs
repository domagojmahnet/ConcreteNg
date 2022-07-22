using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConcreteNg.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
            services.AddScoped<IPricingListRepository, PricingListItemRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
