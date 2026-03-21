using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.Interfaces;

namespace FamilyStoryApi.Application.LevelParentages.Commands
{
    public class CreateLevelParentageCommand : Notifiable, ICommandEntry
    {
        public int LevelParentage { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool Validate()
        {
            if ( this.LevelParentage <= 0)
                this.AddNotification("CreateLevelParentageCommand.Validate: Nível de parentesco inválido");

            if ( string.IsNullOrWhiteSpace(this.Description) )
                this.AddNotification("CreateLevelParentageCommand.Validate: Descrição de parentesco inválido!");

            return this.IsValid;
        }
    }
}
