using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyStoryApi.WebApi.ViewModels
{
    public class ResultViewModel<T>
    {
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();

        public ResultViewModel(T? data = default, List<string>? errors = null)
        {
            Data = data;
            Errors = errors ?? [];
        }
    }
}
