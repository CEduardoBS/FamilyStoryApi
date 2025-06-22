using FamilyStoryApi.Core.Interface.Implementation;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class UserGroupRepositoryImplementation(FamilyStoryContext context)
        : RepositoryCRUD<UserGroup>(context), IUserGroupRepository
    {
        public override async Task<UserGroup> Create(UserGroup group)
        {
            await base.Create(group);
            return group;
        }

        public override async Task<int> Delete(UserGroup group)
        {
            int qtdRowsDeleted = await base.Delete(group);
            return qtdRowsDeleted;
        }

        public override async Task<UserGroup> SoftDelete(UserGroup group)
        {
            UserGroup updatedGroup = await base.Update(group);
            return updatedGroup;
        }

        public override async Task<UserGroup?> GetById(int id)
        {
            UserGroup? foundGroup = await base.GetById(id);
            return foundGroup;
        }

        public override async Task<List<UserGroup>> GetRange(int skip = 0, int take = 10)
        {
            List<UserGroup> groups = [];
            groups = await base.GetRange(skip, take);

            return groups;
        }

        public override async Task<UserGroup> Update(UserGroup group)
        {
            UserGroup updatedGroup = await base.Update(group);
            return updatedGroup;
        }
    }
}
