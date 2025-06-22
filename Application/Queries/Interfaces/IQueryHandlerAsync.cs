namespace FamilyStoryApi.Application.Queries.Interfaces
{
    public interface IQueryHandlerAsync<TQuery, TResult>
    {
        public Task<TResult> HandleAsync(TQuery query);
    }
}
