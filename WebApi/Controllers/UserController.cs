using FamilyStoryApi.Application.Users.Commands;
using FamilyStoryApi.Application.Users.Handlers;
using FamilyStoryApi.Application.Users.Queries.GetUserById;
using FamilyStoryApi.Application.Users.Queries.GetUserByList;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.WebApi.ViewModels;
using FamilyStoryApi.WebApi.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStoryApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize(Roles = "user_create")]
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

            CommandResult<UserInfo> cmdResult = await createUserHandler.HandleAsync(cmdUser);

            if (createUserHandler.IsValid)
            {
                result = new(data: cmdResult);
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

        [Authorize(Roles = "user_read")]
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

        [Authorize(Roles = "user_read")]
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

        [Authorize(Roles = "user_delete")]
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
