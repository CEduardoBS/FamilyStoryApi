using FamilyStoryApi.Domain.ValueObjects;

namespace FamilyStoryApi.WebApi.ViewModels.User
{
    public class CreateUserViewModel
    {
        public Name Name { get; set; }

        public Email Email { get; set; }

        public string PasswordHash { get; set; }

        public int UserGroupId { get; set; }

        public CreateUserViewModel(Name name, Email email, string passwordHash, int userGroupId)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            UserGroupId = userGroupId;
        }
    }
}
