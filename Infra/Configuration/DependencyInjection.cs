using FamilyStoryApi.Application.Auth.Handlers;
using FamilyStoryApi.Application.LevelParentages.Handlers;
using FamilyStoryApi.Application.Relatives.Handlers;
using FamilyStoryApi.Application.Stories.Handlers;
using FamilyStoryApi.Application.Users.Handlers;
using FamilyStoryApi.Application.Users.Queries.GetUserById;
using FamilyStoryApi.Application.Users.Queries.GetUserByList;
using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Core.Interfaces.Repositories;
using FamilyStoryApi.Infra.Repository.Implementation;
using FamilyStoryApi.WebApi.Configurations;
using FamilyStoryApi.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FamilyStoryApi.Infra.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            #region Repositories
            services.AddScoped<IUserInfoRepository, UserInfoRepositoryImplementation>();
            services.AddScoped<IStoryRepository, StoryRepositoryImplementation>();
            services.AddScoped<IRelativesRepository, RelativesRepositoryImplementation>();
            services.AddScoped<ILevelParentageRepository, LevelParentageRepositoryImplementation>();
            #endregion

            #region Handlers
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<DeleteUserHandler>();
            services.AddScoped<AuthHandler>();
            services.AddScoped<CreateStoryHandler>();
            services.AddScoped<CreateRelativeHandler>();
            services.AddScoped<CreateLevelParentageHandler>();
            #endregion

            #region Queries
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<GetUserListByRangeHandler>();
            #endregion

            return services;
        }

        public static IServiceCollection AddAuthorizationJWT(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();

            services.AddAuthentication( auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            } )
            .AddJwtBearer( jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(TokenConfiguration.Key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(name: "Admin", configurePolicy: police => police.RequireRole("admin") );
            });

            return services;
        }
    }
}
