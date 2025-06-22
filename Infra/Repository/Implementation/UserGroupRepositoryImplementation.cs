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
            int qtdRowsDeleted;
            try
            {
                userInfo.IsDeleted = true;

                qtdRowsDeleted = await base.Delete(userInfo);

                if (qtdRowsDeleted <= 0)
                {
                    throw new("Não foi possível deleter o usuário!");
                }
            }
            catch (Exception err)
            {
                throw new(message: "GRP02|", innerException: err);
            }

            return qtdRowsDeleted;
        }

        public override async Task<UserGroup> GetById(int id)
        {
            UserGroup? foundGroup;
            try
            {
                foundGroup = await base.GetById(id);

                if (foundGroup is null)
                    throw new Exception(message: "Usuário não encontrado");
            }
            catch (Exception err)
            {
                throw new("GRP03|", innerException: err);
            }

            return foundGroup!;
        }

        public override async Task<List<UserGroup>> GetRange(int skip = 0, int take = 10)
        {
            List<UserGroup> groups = new();
            try
            {
                groups = await base.GetRange(skip, take);
            }
            catch (Exception err)
            {
                throw new Exception("GRP03|", innerException: err);
            }

            return groups;
        }

        public override async Task<UserGroup> Update(UserGroup userInfo)
        {
            UserGroup? updatedGroup;
            try
            {
                updatedGroup = await base.Update(userInfo);
                if (updatedGroup is null)
                    throw new Exception(message: "Usuário não atualizado");

            }
            catch (Exception)
            {
                throw;
            }

            return updatedGroup;
        }
    }
}
