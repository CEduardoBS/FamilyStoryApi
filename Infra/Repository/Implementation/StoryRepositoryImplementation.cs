using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class StoryRepositoryImplementation(FamilyStoryContext context) :
        RepositoryCRUD<Story>(context), IStoryRepository
    {
        public override Task<Story> Create(Story info)
        {
            return base.Create(info);
        }

        public override Task<int> Delete(Story info)
        {
            return base.Delete(info);
        }

        public override Task<Story> SoftDelete(Story info)
        {
            return base.SoftDelete(info);
        }

        public override Task<Story?> GetById(int id)
        {
            return base.GetById(id);
        }

        public override Task<List<Story>> GetRange(int skip = 0, int take = 10)
        {
            return base.GetRange(skip, take);
        }

        public override Task<Story> Update(Story info)
        {
            return base.Update(info);
        }
    }
}
