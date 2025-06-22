using FamilyStoryApi.Application.Commands.Interfaces;

namespace FamilyStoryApi.Application.Commands.User
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
