using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class RelativesRepositoryImplementation(FamilyStoryContext context) : RepositoryCRUD<Relative>(context)  , IRelativesRepository
    {

    }
}
