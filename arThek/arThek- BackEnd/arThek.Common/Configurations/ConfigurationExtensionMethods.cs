using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using arThek.Infrastructure.Repositories;
using arThek.ServiceAbstraction;
using arThek.Services;
using arThek.Services.Filtering;
using arThek.Services.Filtering.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace arThek.Common.Configurations
{
    public static class ConfigurationExtensionMethods
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<arThekContext>(op
               => op.UseSqlServer(configuration.GetConnectionString("arThekContext"),
                   b => b.MigrationsAssembly("arThek.Infrastructure")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMentorRepository, MentorRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMentorService, MentorService>();
        }

        public static void AddTrainingFilters(this IServiceCollection services)
        {
            services.AddScoped<IMentorConditions, MentorNameCondition>();
            services.AddScoped<IMentorConditions, MentorCategoryCondition>();
            services.AddScoped<IMentorConditions, IsVolunteerCondition>();
            services.AddScoped<IMentorFilterService, MentorFilterService>();
        }
    }
}
