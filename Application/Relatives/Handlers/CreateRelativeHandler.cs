using FamilyStoryApi.Application.Relatives.Commands;
using FamilyStoryApi.Application.Relatives.Results;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Application.Relatives.Handlers
{
    public class CreateRelativeHandler(IRelativesRepository relativesRepository) :
        Notifiable,
        IHandlerAsync<CreateRelativeCommand, CommandResult<CreateRelativeResult>>
    {
        private readonly IRelativesRepository _relativesRepository = relativesRepository;

        public async Task<CommandResult<CreateRelativeResult>> HandleAsync(CreateRelativeCommand command)
        {
            try
            {
                if (!command.Validate())
                {
                    base.AddNotifications(command);
                    return new CommandResult<CreateRelativeResult>(success: false, message: "Dados inválidos");
                }

                var relative = new Relative()
                {
                    UserId = command.UserId,
                    Name = command.Name,
                    LevelParentageId = command.Parentage,
                    BirthDate = command.BirthDay,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = 0,
                    IsActive = 1
                };

                Relative relativeResult = await _relativesRepository.CreateAsync(relative);

                if (relativeResult.RelativesId <= 0)
                {
                    base.AddNotification("Ops! Ocorreu um erro ao tentar criar familiar!");
                    return new CommandResult<CreateRelativeResult>(success: false, message: "Ops! Ocorreu um erro ao tentar criar familiar!");
                }

                CreateRelativeResult result = new(name: relativeResult.Name, relation: relativeResult.Relation);
                return new CommandResult<CreateRelativeResult>(success: true, message: "Familiar criado com sucesso!", data: result);
            }
            catch (Exception err)
            {
                base.AddNotification($"Ops! Ocorreu um erro ao tentar criar familiar! Erro: {err.Message}");
                return new CommandResult<CreateRelativeResult>(
                    success: false,
                    message: $"Ops! Ocorreu um erro ao tentar criar familiar! Erro: {err.Message}");
            }

        }
    }
}
