using FamilyStoryApi.Core.Interfaces;

namespace FamilyStoryApi.Core.Interface
{
    public interface IHandler<T> where T : ICommandEntry
    {
        public ICommandResult Handle(T command);
    }
}
