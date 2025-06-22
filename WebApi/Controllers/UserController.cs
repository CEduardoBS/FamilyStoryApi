using FamilyStoryApi.Application.Commands;
using FamilyStoryApi.Application.Handlers;
using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Business;
using FamilyStoryApi.Domain.ValueObjects;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyStoryApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserInfoBusiness userInfoBusiness ) : ControllerBase
    {
        private readonly IUserInfoBusiness _userInfoBusiness = userInfoBusiness;

        [HttpPost("create")]
        public async Task<IActionResult> CreteUser(
            [FromServices] CreateUserHandler createUserHandler,
            [FromBody] CreateUserViewModel userInfo)
        {
            ResultViewModel<CommandResult<UserInfo>> result;
            try
            {
                CreateUserCommand cmdUser = new(
                     email: userInfo.Email,
                     name: new(firstName: userInfo.Name.FirstName, lastName: userInfo.Name.LastName),
                     passwordHash: userInfo.PasswordHash,
                     userGroupId: userInfo.UserGroupId
                     );

                if (cmdUser.Validate())
                {
                    CommandResult<UserInfo> cmdResult = await createUserHandler.HandleAsync(cmdUser);

                    if (cmdResult.IsValid)
                    {
                        result = new(data: cmdResult);
                    }
                    else
                    {
                        result = new(cmdResult.Notifications.First());
                    }
                }
                else
                {
                    result = new(errors: [.. cmdUser.Notifications]);
                }

            }
            catch (Exception err)
            {
                result = new(error: err.Message.ToString());
            }

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            UserInfo userInfo = await _userInfoBusiness.GetById(id);
            return Ok(userInfo);
        }

        [HttpGet("range/skip={skip:int}&take={take:int}")]
        public async Task<IActionResult> GetUserByRange([FromRoute] int skip, [FromRoute] int take)
        {
            List<UserInfo> userInfo = await _userInfoBusiness.GetByRange(skip, take);

            return Ok(userInfo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userInfoBusiness.Delete(id);
            return Ok("Sucesso");
        }
    }
}
