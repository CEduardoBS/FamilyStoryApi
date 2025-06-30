using FamilyStoryApi.Application.Commands.Auth;
using FamilyStoryApi.Application.Handlers.Auth;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStoryApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> AuthLogin(
            [FromServices] AuthHandler authHandler,
            [FromBody] AuthCommand authCommand
            )
        {
            ResultViewModel<CommandResult<LoginResult>> vwResult;
            CommandResult<LoginResult> cmdResult = await authHandler.HandleAsync(authCommand);

            if (authHandler.IsValid)
            {
                vwResult = new(
                    data: cmdResult);

                return Ok(vwResult);
            }
            else
            {
                vwResult = new(
                    errors: [.. authHandler.Notifications]);

                return BadRequest(vwResult);
            }
        }
    }
}
