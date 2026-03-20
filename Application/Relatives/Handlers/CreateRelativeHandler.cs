using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Relatives.Commands;
using FamilyStoryApi.Application.Relatives.Results;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;

namespace FamilyStoryApi.Application.Relatives.Handlers
{
    public class CreateRelativeHandler(IRelativesRepository relativesRepository) : 
        Notifiable, 
        IHandlerAsync<CreateRelativeCommand, CommandResult<CreateRelativeResult>>
    {
        private readonly IRelativesRepository _relativesRepository = relativesRepository;

        public async Task<CommandResult<CreateRelativeResult>> HandleAsync(CreateRelativeCommand command)
        {
            CommandResult<CreateRelativeResult> cmResult;
            try
            {
                if (command.Validate())
                {
                    Relative relative = new()
                    {
                        UserId = command.UserId,
                        Name = command.Name,
                        LevelParentageId = command.Parentage,
                        BirthDate = command.BirthDay
                    };

                    Relative relativeResult = await _relativesRepository.Create(relative);

                    if (relativeResult.RelativesId > 0)
                    {
                        CreateRelativeResult result = new(name: relativeResult.Name, relation: relativeResult.Relation);
                        cmResult = new CommandResult<CreateRelativeResult>(success: true, message: "Familiar criado com sucesso!", data: result);
                    }
                    else
                    {
                        cmResult = new CommandResult<CreateRelativeResult>(success: false, message: "Ops! Ocorreu um erro ao tentar criar familiar!");
                        base.AddNotification(cmResult.Message);
                    }
                }
                else
                {
                    base.AddNotifications(command);
                    cmResult = new(success: false, message: "Ops! Dados de entrada para criação do parente inválidos!");
                }
            }
            catch (Exception err)
            {
                cmResult = new CommandResult<CreateRelativeResult>(
                    success: false, 
                    message: $"Ops! Ocorreu um erro ao tentar criar familiar! Erro: {err.Message}");
                base.AddNotification(cmResult.Message);
            }

            return cmResult;
        }
    }
}
