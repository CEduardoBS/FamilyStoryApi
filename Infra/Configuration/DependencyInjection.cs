using FamilyStoryApi.Application.Handlers.Auth;
using FamilyStoryApi.Application.Handlers.User;
using FamilyStoryApi.Application.Queries.User.GetUserById;
using FamilyStoryApi.Application.Queries.User.GetUserByList;
using FamilyStoryApi.Application.Services;
using FamilyStoryApi.Business;
using FamilyStoryApi.Business.Implementation;
using FamilyStoryApi.Core.Configurations;
using FamilyStoryApi.Infra.Repository;
using FamilyStoryApi.Infra.Repository.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FamilyStoryApi.Infra.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IUserInfoRepository, UserInfoRepositoryImplementation>();
            services.AddScoped<IUserInfoBusiness, UserInfoBusinessImplementation>();
            
            // Handlers
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<DeleteUserHandler>();
            services.AddScoped<AuthHandler>();

            //Queries
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<GetUserListByRangeHandler>();



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
