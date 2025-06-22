using FamilyStoryApi.Core.Entities;

namespace FamilyStoryApi.Application.Commands.Interfaces
{
    public interface ICommandEntry
    {
        public bool Validate();
    }
}
