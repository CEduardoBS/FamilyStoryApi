using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interfaces;

namespace FamilyStoryApi.Application.Stories.Commands
{
    public class CreateStoryCommand : Notifiable, ICommandEntry
    {
        public int UserId { get; set; }
        public int RelativeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public bool Validate()
        {
            bool canContinue = true;

            if (UserId <= 0)
            {
                canContinue = false;
                base.AddNotification("Id de usuário inválido!");
            }

            if (string.IsNullOrEmpty(Title))
            {
                canContinue = false;
                base.AddNotification("O Título da história não pode ficar em branco!");
            }

            if (string.IsNullOrEmpty(Content))
            {
                canContinue = false;
                base.AddNotification("O conteúdo da história não pode ficar em branco!");
            }

            return canContinue;
        }
    }
}
