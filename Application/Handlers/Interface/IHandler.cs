using FamilyStoryApi.Application.Commands.Interfaces;
using FamilyStoryApi.Application.Results.Interfaces;

namespace FamilyStoryApi.Application.Handlers.Interface
{
    public interface IHandler<T> where T : ICommandEntry
    {
        public ICommandResult Handle(T command);
    }
}
