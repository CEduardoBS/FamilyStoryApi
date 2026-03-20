namespace FamilyStoryApi.Core.Interface
{
    public interface IQueryHandlerAsync<TQuery, TResult>
    {
        public Task<TResult> HandleAsync(TQuery query);
    }
}
