using FamilyStoryApi.Application.Commands.User;
using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Handlers.User;
using FamilyStoryApi.Application.Queries.User.GetUserById;
using FamilyStoryApi.Application.Queries.User.GetUserByList;
using FamilyStoryApi.Application.Queries.User.GetUserList;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Business;
using FamilyStoryApi.Domain.ValueObjects;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.WebApi.ViewModels;
using FamilyStoryApi.WebApi.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyStoryApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserInfoBusiness userInfoBusiness) : ControllerBase
    {
        private readonly IUserInfoBusiness _userInfoBusiness = userInfoBusiness;

        [HttpPost("create")]
        public async Task<IActionResult> CreteUser(
            [FromServices] CreateUserHandler createUserHandler,
            [FromBody] CreateUserViewModel userInfo)
        {
            ResultViewModel<CommandResult<UserInfo>> result;

            CreateUserCommand cmdUser = new(
                 email: userInfo.Email,
                 name: new(firstName: userInfo.Name.FirstName, lastName: userInfo.Name.LastName),
                 passwordHash: userInfo.PasswordHash,
                 userGroupId: userInfo.UserGroupId
                 );

            if (cmdUser.Validate())
            {
                CommandResult<UserInfo> cmdResult = await createUserHandler.HandleAsync(cmdUser);

                if (createUserHandler.IsValid)
                {
                    result = new(data: cmdResult);
                }
                else
                {
                    result = new(errors: [.. createUserHandler.Notifications]);
                }
            }
            else
            {
                result = new(errors: [.. createUserHandler.Notifications]);
            }

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetUser(
            [FromServices] GetUserByIdHandler handler,
            [FromRoute] int id)
        {
            GetUserByIdQuery query = new(id);
            GetUserViewModel userInfo = await handler.HandleAsync(query);
            ResultViewModel<UserInfo> result;

            if (handler.IsValid)
            {
                return Ok(userInfo);
            }
            else
            {
                result = new(errors: [.. handler.Notifications]);
            }

            return BadRequest(result);
        }

        [HttpGet("range/skip={skip:int}&take={take:int}")]
        public async Task<IActionResult> GetUserByRange(
            [FromServices] GetUserListByRangeHandler handler,
            [FromRoute] int skip, [FromRoute] int take)
        {
            GetUserListByRangeQuery query = new(skip, take);
            IList<GetUserViewModel> users = await handler.HandleAsync(query);
            ResultViewModel<List<GetUserViewModel>> result;

            if (handler.IsValid)
            {
                result = new(data: [.. users]);
                return Ok(result);
            }
            else
            {
                result = new(errors: [.. handler.Notifications]);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(
            [FromServices] DeleteUserHandler deleteHandler,
            [FromRoute] int id)
        {
            ResultViewModel<CommandResult<bool>> rvModel;

            DeleteUserCommand commandEntry = new DeleteUserCommand(id);
            CommandResult<bool> result = await deleteHandler.HandleAsync(commandEntry);

            if (deleteHandler.IsValid)
            {
                rvModel = new(data: result);
                return Ok(rvModel);
            }
            else
            {
                rvModel = new(errors: [.. deleteHandler.Notifications]);
            }

            return BadRequest(rvModel);
        }
    }
}
