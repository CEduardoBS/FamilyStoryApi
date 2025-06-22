using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyStoryApi.WebApi.ViewModels
{
    public class ResultViewModel<T>
    {
        public T? Data { get; private set; }

        public List<string> Errors { get; private set; } = new();

        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(List<string> errors)
        {
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }

        public ResultViewModel(string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                Errors.Add(error);
            }
        }

        public void Reset()
        {
            Errors.Clear();
        }
    }
}
