using FamilyStoryApi.Application.Commands.Interfaces;
using FamilyStoryApi.Core.Entities;

namespace FamilyStoryApi.Application.Relatives.Commands
{
    public class CreateRelativeCommand : Notifiable, ICommandEntry
    {
        public int UserId { get; set; }
        public string Name {
            get { return name; }
            set { name = value.Trim(); }
        }

        public int Parentage { get; set; }
        public DateTime BirthDay { get; set; }

        string name = string.Empty;

        public bool Validate()
        {
            DateTime dtNow = DateTime.UtcNow;

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                base.AddNotification("Nome do parente está em branco! Informe o nome do parente, por favor!");
            }

            if (this.Name.Length > 150)
            {
                base.AddNotification("Nome do parente inválido! O nome deve ter no máximo 150 caracteres!");
            }

            if (this.Parentage <= 0)
            {
                base.AddNotification("Grau de parentesco não informado! Por favor, informe o grau de parentesco!");
            }

            if (this.BirthDay > dtNow)
            {
                base.AddNotification("Data de aniversário inválida! A data de aniversário não pode ser posterior a hoje!");
            }

            return base.IsValid;
        }
    }
}
