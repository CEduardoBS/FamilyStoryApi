using FamilyStoryApi.Application.Queries.Interfaces;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;
using FamilyStoryApi.WebApi.ViewModels.User;

namespace FamilyStoryApi.Application.Queries.User.GetUserById
{
    public class GetUserByIdHandler(IUserInfoRepository userInfoRepository) : Notifiable, IQueryHandlerAsync<GetUserByIdQuery, GetUserViewModel>
    {
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;
        public async Task<GetUserViewModel> HandleAsync(GetUserByIdQuery query)
        {
            GetUserViewModel result = new();
            try
            {
                UserInfo userInfo = await _userInfoRepository.GetById(query.Id);

                if (userInfo.UserId > 0)
                {
                    result = new(id: userInfo.UserId, name: userInfo.Name, email: userInfo.Email, createAt: userInfo.CreateAt);
                }
                else
                {
                    this.AddNotification("GetUserByIdHandler.HandlerAsync: Não foi possível encontrar o usuário com os dados fornecidos!");
                }
            }
            catch (Exception err)
            {
                this.AddNotification($"GetUserByIdHandler.HandlerAsync: Não foi possível encontrar o usuário com os dados fornecidos! {err.Message}");
            }

            return result;
        }
    }
}
