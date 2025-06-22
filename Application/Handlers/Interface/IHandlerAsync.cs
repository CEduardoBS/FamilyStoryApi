using FamilyStoryApi.Application.Commands.Interfaces;
using FamilyStoryApi.Application.Results.Interfaces;

namespace FamilyStoryApi.Application.Handlers.Interface
{
    public interface IHandlerAsync<C, R> where C : ICommandEntry where R : ICommandResult
    {
        public Task<R> HandleAsync(C command);
    }
}
