using FamilyStoryApi.Application.Commands;
using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Application.Results.Interfaces;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;

namespace FamilyStoryApi.Application.Handlers
{
    public class CreateUserHandler(IUserInfoRepository userInfoRepository) : Notifiable, IHandlerAsync<CreateUserCommand, CommandResult<UserInfo>>
    {
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;

        public async Task<CommandResult<UserInfo>> HandleAsync(CreateUserCommand command)
        {
            CommandResult<UserInfo> cmResult;
            try
            {
                UserInfo newUser = new()
                {
                    CreateAt = DateTime.Now,
                    Email = command.Email.Address,
                    IsActive = true,
                    IsDeleted = false,
                    Name = command.Name.ToString(),
                    PasswordHash = command.PasswordHash,
                    UserGroupId = command.UserGroupId,
                    UserGroup = null,
                    UserId = 0
                };

                UserInfo userCreated = await _userInfoRepository.Create(newUser);

                if (userCreated.UserId > 0)
                {
                    cmResult = new(
                            success: true,
                            message: "Sucesso ao criar usuário!",
                            data: userCreated
                        );
                }
                else
                {
                    cmResult = new(
                            success: false,
                            message: "Não foi´possível criar o usuário!"
                        );
                }
            }
            catch (Exception err)
            {
                cmResult = new(
                           success: false,
                           message: $"Não foi´possível criar o usuário! {err.Message}"
                       );
            }

            return cmResult;
        }
    }
}
