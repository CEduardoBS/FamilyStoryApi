using FamilyStoryApi.Application.Handlers.User;
using FamilyStoryApi.Application.Queries.User.GetUserById;
using FamilyStoryApi.Application.Queries.User.GetUserByList;
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
            
            // Handlers
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<DeleteUserHandler>();

            //Queries
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<GetUserListByRangeHandler>();

            return services;
        }
    }
}
