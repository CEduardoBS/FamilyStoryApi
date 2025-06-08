using FamilyStoryApi.Core.Interface.Implementation;
using FamilyStoryApi.Data;
using FamilyStoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Repository.Implementation
{
    public class UserGroupRepositoryImplementation(FamilyStoryContext context) 
        : RepositoryCRUD<UserGroup>(context), IUserGroupRepository
    {
        public override async Task<UserGroup> Create(UserGroup group)
        {
            try
            {
                UserGroup groupCreated = await base.Create(group);

                if (groupCreated.GroupId <= 0)
                {
                    throw new Exception("Ops! Parece que o grupo não foi gravado corretamente");
                }

                return groupCreated;
            }
            catch(Exception err)
            {
                throw new(message: "GRP01|", innerException: err);
            }
        }

        public override async Task<int> Delete(UserGroup userInfo)
        {
            throw new NotImplementedException();
        }

        public override async Task<UserGroup> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<UserGroup>> GetRange(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public override async Task<UserGroup> Update(UserGroup userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
