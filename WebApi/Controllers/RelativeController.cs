using FamilyStoryApi.Application.Relatives.Commands;
using FamilyStoryApi.Application.Relatives.Handlers;
using FamilyStoryApi.Application.Relatives.Results;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FamilyStoryApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelativeController : ControllerBase
    {
        [HttpPost("create")]
        //[Authorize(Roles = "relative_create")]
        public async Task<IActionResult> CreateRelative([FromServices] CreateRelativeHandler handler, [FromBody] CreateRelativeCommand command)
        {
            CommandResult<CreateRelativeResult> cmResult = await handler.HandleAsync(command);

            if (handler.IsValid) 
            {
                ResultViewModel<CommandResult<CreateRelativeResult>> vmResult = new(data: cmResult);
                return Ok(vmResult);
            }
            else
            {
                ResultViewModel<CommandResult<CreateRelativeResult>> vmResult = new(errors: [..handler.Notifications]);
                return BadRequest(vmResult);
            }
            
        }
    }
}
