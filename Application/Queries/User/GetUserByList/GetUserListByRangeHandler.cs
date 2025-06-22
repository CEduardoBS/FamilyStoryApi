using FamilyStoryApi.Application.Queries.Interfaces;
using FamilyStoryApi.Application.Queries.User.GetUserList;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;
using FamilyStoryApi.WebApi.ViewModels.User;
using System.Collections.Generic;

namespace FamilyStoryApi.Application.Queries.User.GetUserByList
{
    public class GetUserListByRangeHandler(IUserInfoRepository userInfoRepository) : Notifiable, IQueryHandlerAsync<GetUserListByRangeQuery, List<GetUserViewModel>>
    {
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;
        public async Task<List<GetUserViewModel>> HandleAsync(GetUserListByRangeQuery query)
        {
            List<GetUserViewModel> users = [];
            try
            {
                List<UserInfo> listUsers = await _userInfoRepository.GetRange(query.SkipQtdUsers, query.TakeQtdUsers);

                if (listUsers.Count > 0)
                {
                    foreach (var user in listUsers)
                    {
                        users.Add(
                            new(id: user.UserId, name: user.Name, email: user.Email, createAt: user.CreateAt));
                    }
                }
                else
                {
                    this.AddNotification("GetUserListByRangeHandler.HandleAsync: Não foi possível encontrar usuários no intervalo definido!");
                }
            }
            catch (Exception err)
            {
                this.AddNotification($"GetUserListByRangeHandler.HandleAsync: Não foi possível encontrar usuários no intervalo definido! {err.Message}");
            }

            return users;
        }
    }
}
