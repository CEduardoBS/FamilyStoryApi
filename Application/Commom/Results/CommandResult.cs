using FamilyStoryApi.Core.Interfaces;

namespace FamilyStoryApi.Application.Commom.Results
{
    public class CommandResult<T> : ICommandResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = [];

        public CommandResult(string message, bool success, T? data, List<string>? errors = null)
        {
            Message = message;
            Success = success;
            Data = data;
            Errors = errors ?? [];
        }

        public CommandResult(string message, bool success, List<string>? errors = null)
        {
            Message = message;
            Success = success;
            Errors = errors ?? [];
        }
    }
}
