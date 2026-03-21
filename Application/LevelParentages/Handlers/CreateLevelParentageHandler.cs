using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.LevelParentages.Commands;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interfaces.Repositories;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Application.LevelParentages.Handlers
{
    public class CreateLevelParentageHandler(ILevelParentageRepository repository) : Notifiable, IHandlerAsync<CreateLevelParentageCommand, CommandResult<CreateLevelParentageCommand>>
    {
        private readonly ILevelParentageRepository _repository = repository;

        public async Task<CommandResult<CreateLevelParentageCommand>> HandleAsync(CreateLevelParentageCommand command)
        {
            try
            {
                if (!command.Validate())
                {
                    this.AddNotifications(command);
                    return new CommandResult<CreateLevelParentageCommand>(
                        success: false, message: "CreateLevelParentageHandler.HandleAsync: Dados de entrada inválidos!");
                }

                var levelParentage = new LevelParentage()
                {
                    Description = command.Description,
                    Level = command.LevelParentage
                };

                var dbResult = await _repository.CreateAsync(levelParentage);

                if( dbResult.LevelParentageId <= 0 )
                {
                    this.AddNotification("CreateLevelParentageHandler.HandleAsync.Create: Não foi possível criar o parentesco!");
                    return new CommandResult<CreateLevelParentageCommand>(
                        success: false, message: "CreateLevelParentageHandler.HandleAsync.Create: Não foi possível criar o parentesco!");
                }

                return new CommandResult<CreateLevelParentageCommand>(
                        success: true, message: "Sucesso ao criar parentesco!", data: command);

            }
            catch (Exception err)
            {
                this.AddNotification($"CreateLevelParentageHandler.HandleAsync - error: {err.Message}");
                return new CommandResult<CreateLevelParentageCommand>(
                    success: false, message: $"CreateLevelParentageHandler.HandleAsync - error: {err.Message}");
            }
        }
    }
}
