using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.Stories.Results;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Entities;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FamilyStoryApi.Application.Stories.Queries.GetStoryById
{
    public class GetStoryByIdHandler(IStoryRepository repository) : Notifiable, IQueryHandlerAsync<GetStoryByIdQuery, CommandResult<GetStoryByIdResult>>
    {
        private readonly IStoryRepository _repository = repository;

        public async Task<CommandResult<GetStoryByIdResult>> HandleAsync(GetStoryByIdQuery query)
        {
            try
            {
                if ( !query.Validate() )
                {
                    base.AddNotifications(query);
                    return new CommandResult<GetStoryByIdResult>(
                            success: false,
                            message: "Dados para consultar story inválidos."
                        );
                }

                Story? story = await _repository.GetByIdAsync(query.StoryId);

                if ( story is null || story.StoryId <= 0 )
                {
                    base.AddNotification($"História não encontrada com o id informado: {query.StoryId}");
                    return new CommandResult<GetStoryByIdResult>(
                            success: false,
                            message: $"Não foi possível encontrar a história com o Id informado: {query.StoryId}"
                        );
                }

                var result = new GetStoryByIdResult ()
                {
                    StoryId = story.StoryId,
                    UserId = story.UserId,
                    RelativesId = story.RelativesId,
                    Title = story.Title,
                    Content = story.Content,
                    MediaUrl = story.MediaUrl,
                    MediaType = story.MediaType,
                    CreateAt = story.CreateAt,
                    IsActive = story.IsActive,
                };

                return new CommandResult<GetStoryByIdResult>(
                        success: true,
                        message: "Sucesso ao consultar story.",
                        data: result
                    );
            }
            catch (Exception err)
            {
                base.AddNotification($"Erro interno: Ocorreu um erro ao tentar encontrar Story informada: {err.Message}");
                return new CommandResult<GetStoryByIdResult>(
                        success: false,
                        message: "Ocorreu um erro ao tentar encontrar Story informada."
                    );
            }
        }
    }
}
