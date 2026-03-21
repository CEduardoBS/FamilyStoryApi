namespace FamilyStoryApi.Application.Users.Queries.GetUserByList
{
    public class GetUserListByRangeQuery()
    {
        public int SkipQtdUsers {  get; set; }
        public int TakeQtdUsers {  get; set; }

        public GetUserListByRangeQuery(int skipQtdUser, int takeQtdUsers) : this()
        {
            SkipQtdUsers = skipQtdUser;
            TakeQtdUsers = takeQtdUsers;
        }
    }
}
