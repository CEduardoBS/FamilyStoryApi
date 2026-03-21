using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.Stories.Commands;
using FamilyStoryApi.Application.Stories.Results;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Application.Stories.Handlers
{
    public class CreateStoryHandler(IStoryRepository storyRepository) : Notifiable, IHandlerAsync<CreateStoryCommand, CommandResult<CreateStoryResult>>
    {
        private readonly IStoryRepository _storyRepository = storyRepository;

        public async Task<CommandResult<CreateStoryResult>> HandleAsync(CreateStoryCommand command)
        {
            CommandResult<CreateStoryResult> commandResult;
            try
            {
                if (command.Validate())
                {
                    Story story = new()
                    {
                        UserId = command.UserId,
                        RelativesId = command.RelativeId,
                        Title = command.Title,
                        Content = command.Content,
                        CreateAt = DateTime.UtcNow,
                        IsActive = 1,
                        IsDeleted = 0
                    };

                    Story storyResult = await _storyRepository.CreateAsync(story);

                    if (storyResult.StoryId > 0)
                    {
                        var result = new CreateStoryResult(storyResult.StoryId, storyResult.Title, storyResult.CreateAt.ToString("yyyy-MM-dd HH:mm:ss"));

                        commandResult = new(
                                success: true,
                                data: result,
                                message: "Sucesso ao salvar história!"
                            );
                    }
                    else
                    {
                        commandResult = new(success: false, message: "CreateStoryHandler.HandlerAsync: Ops! Não foi possível salvar a história!");
                        base.AddNotification(commandResult.Message);
                    }
                }
                else
                {
                    commandResult = new(success: false, message: "CreateStoryHandler.HandlerAsync: Ops! Não foi possível salvar a história!");
                    base.AddNotifications(command);
                }
            }
            catch (Exception err)
            {
                commandResult = new(
                        success: false,
                        message: $"Erro ao salvar história: {err.Message}"
                    );

                base.AddNotification(commandResult.Message);
            }

            return commandResult;
        }
    }
}
