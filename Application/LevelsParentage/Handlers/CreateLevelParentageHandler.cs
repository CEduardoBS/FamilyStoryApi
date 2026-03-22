using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.LevelParentages.Commands;
using FamilyStoryApi.Application.LevelParentages.Results;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interfaces.Repositories;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Application.LevelParentages.Handlers
{
    public class CreateLevelParentageHandler(ILevelParentageRepository repository) :
        Notifiable, IHandlerAsync<CreateLevelParentageCommand, CommandResult<CreateLevelParentageResult>>
    {
        private readonly ILevelParentageRepository _repository = repository;

        public async Task<CommandResult<CreateLevelParentageResult>> HandleAsync(CreateLevelParentageCommand command)
        {
            try
            {
                if (!command.Validate())
                {
                    this.AddNotifications(command);
                    return new CommandResult<CreateLevelParentageResult>(
                        success: false, message: "CreateLevelParentageHandler.HandleAsync: Dados de entrada inválidos!", errors: [.. this.Notifications]);
                }

                var levelParentage = new LevelParentage()
                {
                    Description = command.Description,
                    Level = command.LevelParentage,
                    IsActive = 1
                };

                var dbResult = await _repository.CreateAsync(levelParentage);

                if (dbResult.LevelParentageId <= 0)
                {
                    this.AddNotification("CreateLevelParentageHandler.HandleAsync.Create: Não foi possível criar o parentesco!");
                    return new CommandResult<CreateLevelParentageResult>(
                        success: false, message: "CreateLevelParentageHandler.HandleAsync.Create: Não foi possível criar o parentesco!", errors: [.. this.Notifications]);
                }

                var result = new CreateLevelParentageResult(
                    id: dbResult.LevelParentageId,
                    level: dbResult.Level,
                    description: dbResult.Description
                    );

                return new CommandResult<CreateLevelParentageResult>(
                        success: true, message: "Sucesso ao criar parentesco!", data: result, errors: [.. this.Notifications]);

            }
            catch (Exception err)
            {
                this.AddNotification($"CreateLevelParentageHandler.HandleAsync - error: {err.Message}");
                return new CommandResult<CreateLevelParentageResult>(
                    success: false, message: $"CreateLevelParentageHandler.HandleAsync - error: {err.Message}", errors: [.. this.Notifications]);
            }
        }
    }
}
