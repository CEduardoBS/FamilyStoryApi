using FamilyStoryApi.Application.Commands.User;
using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;

namespace FamilyStoryApi.Application.Handlers.User
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
                    UserInfo user = await _userInfoRepository.GetById(command.Id);
                    if (user.UserId > 0)
                    {
                        int qtdRowsDeleted = await _userInfoRepository.Delete(user);
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
