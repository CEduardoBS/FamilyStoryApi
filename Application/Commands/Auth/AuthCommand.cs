using FamilyStoryApi.Application.Commands.Interfaces;
using FamilyStoryApi.Domain.ValueObjects;

namespace FamilyStoryApi.Application.Commands.Auth
{
    public class AuthCommand : ICommandEntry
    {
        public Email Login { get; set; }
        public string Password { get; set; } = string.Empty;

        public AuthCommand(Email login, string password)
        {
            Login = login;
            Password = password;
        }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Login.Address) && !string.IsNullOrEmpty(Password);
        }
    }
}
