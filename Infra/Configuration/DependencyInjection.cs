using FamilyStoryApi.Application.Handlers.Auth;
using FamilyStoryApi.Application.Handlers.User;
using FamilyStoryApi.Application.Queries.User.GetUserById;
using FamilyStoryApi.Application.Queries.User.GetUserByList;
using FamilyStoryApi.Infra.Repository;
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
            #endregion

            #region Handlers
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<DeleteUserHandler>();
            services.AddScoped<AuthHandler>();
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
