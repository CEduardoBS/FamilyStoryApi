using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.Users.Commands;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Application.Users.Handlers
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
                        CreateAt = DateTime.UtcNow,
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
                    UserInfo userCreated = await _userInfoRepository.CreateAsync(newUser);

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
