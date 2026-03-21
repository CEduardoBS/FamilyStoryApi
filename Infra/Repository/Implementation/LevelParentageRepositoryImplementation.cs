using FamilyStoryApi.Core.Interfaces.Repositories;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class LevelParentageRepositoryImplementation(FamilyStoryContext context) : RepositoryCRUD<LevelParentage>(context), ILevelParentageRepository
    {

    }
}
