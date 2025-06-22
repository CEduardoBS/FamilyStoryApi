using FamilyStoryApi.Application.Results.Interfaces;
using FamilyStoryApi.Core.Entities;

namespace FamilyStoryApi.Application.Results
{
    public class CommandResult<T> : ICommandResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }

        public CommandResult(string message, bool success, T? data)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public CommandResult(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
