using FamilyStoryApi.Application.Handlers;
using FamilyStoryApi.Business;
using FamilyStoryApi.Business.Implementation;
using FamilyStoryApi.Infra.Repository;
using FamilyStoryApi.Infra.Repository.Implementation;

namespace FamilyStoryApi.Infra.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IUserInfoRepository, UserInfoRepositoryImplementation>();
            services.AddScoped<IUserInfoBusiness, UserInfoBusinessImplementation>();

            services.AddScoped<CreateUserHandler>();

            return services;
        }
    }
}
