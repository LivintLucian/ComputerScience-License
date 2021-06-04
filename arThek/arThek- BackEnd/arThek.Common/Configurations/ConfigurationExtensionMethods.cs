﻿using arThek.Entities.RepositoryInterfaces;
using arThek.Infrastructure.Persistence;
using arThek.Infrastructure.Repositories;
using arThek.ServiceAbstraction;
using arThek.Services;
using arThek.Services.Filtering;
using arThek.Services.Filtering.Conditions;
using Microsoft.AspNet.SignalR;
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
            services.AddScoped<IMenteeRepository, MenteeRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IBaseUserRepository, BaseUserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IChatMessengerBetweenUsersRepository, ChatMessengerBetweenUsersRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IMenteeNotificationRepository, MenteeNotificationRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IMenteeService, MenteeService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IBaseUserService, BaseUserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<ILiveStreamingService, LiveStreamingService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IChatMessengerBetweenUsersService, ChatMessengerBetweenUsersService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMenteeNotificationService, MenteeNotificationService>();
        }
        public static void AddMentorFilters(this IServiceCollection services)
        {
            services.AddScoped<IMentorConditions, MentorNameCondition>();
            services.AddScoped<IMentorConditions, MentorCategoryCondition>();
            services.AddScoped<IMentorConditions, IsVolunteerCondition>();
            services.AddScoped<IMentorFilterService, MentorFilterService>();
        }
        public static void AddArticleFilters(this IServiceCollection services)
        {
            services.AddScoped<IArticleConditions, ArticleCategoryCondition>();
            services.AddScoped<IArticleFilterService, ArticleFilterService>();
        }
    }
}
