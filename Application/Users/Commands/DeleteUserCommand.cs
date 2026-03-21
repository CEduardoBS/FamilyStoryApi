using FamilyStoryApi.Core.Interfaces;

namespace FamilyStoryApi.Application.Users.Commands
{
    public class DeleteUserCommand : ICommandEntry
    {
        public int Id { get; set; }

        public DeleteUserCommand( int id) 
        {
            Id = id;
        }

        public bool Validate()
        {
            return Id > 0;
        }
    }
}
