using FamilyStoryApi.Application.Commands.User;
using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Application.Results.Interfaces;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;

namespace FamilyStoryApi.Application.Handlers.User
{
    public class CreateUserHandler(IUserInfoRepository userInfoRepository) : Notifiable, IHandlerAsync<CreateUserCommand, CommandResult<UserInfo>>
    {
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;

        public async Task<CommandResult<UserInfo>> HandleAsync(CreateUserCommand command)
        {
            CommandResult<UserInfo> cmdResult;
            try
            {

                if (command.Validate()) 
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

                    newUser.PasswordToBase64();
                    UserInfo userCreated = await _userInfoRepository.Create(newUser);

                    if (userCreated.UserId > 0)
                    {
                        cmdResult = new(
                                success: true,
                                message: "Sucesso ao criar usuário!",
                                data: userCreated
                            );
                    }
                    else
                    {
                        cmdResult = new(
                                success: false,
                                message: "Não foi possível criar o usuário!"
                            );

                        this.AddNotification(cmdResult.Message);
                    }
                }
                else
                {
                    cmdResult = new(
                           success: false,
                           message: $"Não foi possível criar o usuário!"
                       );
                    this.AddNotifications(command);
                }
            }
            catch (Exception err)
            {
                cmdResult = new(
                           success: false,
                           message: $"Não foi possível criar o usuário! {err.Message}"
                       );

                this.AddNotification(cmdResult.Message);
            }

            return cmdResult;
        }
    }
}
