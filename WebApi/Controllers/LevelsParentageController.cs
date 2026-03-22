using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.LevelParentages.Commands;
using FamilyStoryApi.Application.LevelParentages.Handlers;
using FamilyStoryApi.Application.LevelParentages.Results;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStoryApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelsParentageController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromServices] CreateLevelParentageHandler handler,
            [FromBody] CreateLevelParentageCommand command
            )
        {
            CommandResult<CreateLevelParentageResult> handlerResult = await handler.HandleAsync(command);

            if (!handlerResult.Success)
                return BadRequest(handlerResult);

            return Ok(handlerResult);
        }
    }
}
