using FamilyStoryApi.Core.Interface.Implementation;
using FamilyStoryApi.Data;
using FamilyStoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Repository.Implementation
{
    public class UserInfoRepositoryImplementation(FamilyStoryContext dbContext) : 
        RepositoryCRUD<UserInfo>(dbContext),
        IUserInfoRepository
    {
        public override async Task<UserInfo> Create(UserInfo userInfo)
        {
            UserInfo? createdUser;

            try
            {
                createdUser = await base.Create(userInfo);

                if (createdUser.UserId <= 0)
                {
                    throw new Exception("Ops! Parece que o usuário não foi gravado corretamente");
                }
            }
            catch (Exception err)
            {
                throw new(message: "USR01|", innerException: err);
            }

            return createdUser;
        }

        public override async Task<int> Delete(UserInfo userInfo)
        {
            int qtdRowsDeleted = 0;
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
                throw new(message: "USR02|", innerException: err);
            }

            return qtdRowsDeleted;
        }

        public override async Task<UserInfo> GetById(int id)
        {
            UserInfo? foundUser;
            try
            {
                foundUser = await base.GetById(id);

                if (foundUser is null)
                    throw new Exception(message: "Usuário não encontrado");
            }
            catch (Exception err)
            {
                throw new("USR3|", innerException: err);
            }

            return foundUser!;
        }

        public override async Task<List<UserInfo>> GetRange(int skip = 0, int take = 10)
        {
            List<UserInfo> users = new();
            try
            {
                users = await base.GetRange(skip, take);
            }
            catch (Exception err)
            {
                throw new Exception("USR4|", innerException: err);
            }

            return users;
        }

        public override async Task<UserInfo> Update(UserInfo userInfo)
        {
            UserInfo? updatedUser;
            try
            {

                updatedUser = await base.Update(userInfo);
                if (updatedUser is null)
                    throw new Exception(message: "Usuário não atualizado");

            }
            catch (Exception)
            {
                throw;
            }

            return updatedUser;
        }
    }
}
