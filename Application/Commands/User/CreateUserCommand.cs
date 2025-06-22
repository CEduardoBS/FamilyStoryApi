using FamilyStoryApi.Application.Commands.Interfaces;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Domain.ValueObjects;

namespace FamilyStoryApi.Application.Commands.User
{
    public class CreateUserCommand : Notifiable, ICommandEntry
    {
        public Name Name { get; set; }

        public Email Email { get; set; }

        public string PasswordHash { get; set; }

        public int UserGroupId { get; set; }

        public CreateUserCommand(Name name, Email email, string passwordHash, int userGroupId)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            UserGroupId = userGroupId;
        }

        public bool Validate()
        {
            AddNotifications(Name, Email);
            return IsValid;
        }
    }
}
