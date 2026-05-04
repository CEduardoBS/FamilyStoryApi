using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interfaces;

namespace FamilyStoryApi.Application.Stories.Queries.GetStoryById
{
    public class GetStoryByIdQuery : Notifiable, IQueryEntry
    {
        public int StoryId { get; set; }

        public bool Validate()
        {
            if (this.StoryId <= 0)
            {
                base.AddNotification("Id de referência para Story está inválido! Por favor, verifique o ID e tente novamente.");
            }
            return base.IsValid;
        }
    }
}
