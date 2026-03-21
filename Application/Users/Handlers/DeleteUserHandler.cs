using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.Users.Commands;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Application.Users.Handlers
{
    public class DeleteUserHandler(IUserInfoRepository userInfoRepository) : Notifiable, IHandlerAsync<DeleteUserCommand, CommandResult<bool>>
    {
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;
        public async Task<CommandResult<bool>> HandleAsync(DeleteUserCommand command)
        {
            CommandResult<bool> result;
            try
            {
                if (!command.Validate())
                {
                    result = new(message: "DeleteUserHandler.HandleAsync: Id inválido, por favor verificar!", success: false, data: false);
                    this.AddNotification("DeleteUserHandler.HandleAsync: Id inválido, por favor verificar!");
                }
                else
                {
                    UserInfo? user = await _userInfoRepository.GetByIdAsync(command.Id);
                    if (user is not null && user.UserId > 0)
                    {
                        int qtdRowsDeleted = await _userInfoRepository.DeleteAsync(user);
                        if (qtdRowsDeleted > 0)
                        {
                            result = new(message: "Sucesso ao deletar usuário!", success: true, data: true);
                        }
                        else
                        {
                            result = new(message: "DeleteUserHandler.HandleAsync: Não foi possível deletar o usuário!", success: false, data: false);
                            this.AddNotification(result.Message);
                        }
                    }
                    else
                    {
                        result = new(message: "DeleteUserHandler.HandleAsync: Não foi possível encontrar o usuário!", success: false, data: false);
                        this.AddNotification(result.Message);
                    }
                }
            }
            catch (Exception err)
            {
                result = new(message: $"Erro ao tentar deletar usuário: {err.Message}", success: false, data: false);
                this.AddNotification(result.Message);
            }

            return result;
        }
    }
}
