using FamilyStoryApi.Core.Interface.Implementation;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class RelativesRepositoryImplementation(FamilyStoryContext context) : RepositoryCRUD<Relatives>(context)  , IRelativesRepository
    {

    }
}
