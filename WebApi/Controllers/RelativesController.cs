using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.Relatives.Commands;
using FamilyStoryApi.Application.Relatives.Handlers;
using FamilyStoryApi.Application.Relatives.Results;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyStoryApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelativesController : ControllerBase
    {
        [HttpPost("create")]
        //[Authorize(Roles = "relative_create")]
        public async Task<IActionResult> CreateRelative([FromServices] CreateRelativeHandler handler, [FromBody] CreateRelativeCommand command)
        {
            string? userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized(new ResultViewModel<object>(errors: ["Usuário autenticado inválido."]));
            }

            command.UserId = userId;

            CommandResult<CreateRelativeResult> cmResult = await handler.HandleAsync(command);

            if (cmResult.Success)    
            {
                ResultViewModel<CommandResult<CreateRelativeResult>> vmResult = new(data: cmResult);
                return Ok(vmResult);
            }

            ResultViewModel<CommandResult<CreateRelativeResult>> vmError = new(errors: [..handler.Notifications]);
            return BadRequest(vmError);
        }
    }
}
