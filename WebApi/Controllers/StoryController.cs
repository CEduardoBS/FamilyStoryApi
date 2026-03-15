using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Application.Stories.Commands;
using FamilyStoryApi.Application.Stories.Handlers;
using FamilyStoryApi.Application.Stories.Results;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStoryApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {
        [HttpPost("create")]
        //[Authorize(Roles = "story_create")]
        public async Task<IActionResult> CreateStory(
            [FromServices] CreateStoryHandler handler,
            [FromBody] CreateStoryCommand command)
        {

            CommandResult<CreateStoryResult> cmResult = await handler.HandleAsync(command);
            ResultViewModel<CommandResult<CreateStoryResult>> rvModel;

            if (handler.IsValid)
            {
                rvModel = new(data: cmResult);
                return Ok(rvModel);
            }
            else
            {
                rvModel = new(errors: [..handler.Notifications]);
                return BadRequest(rvModel);
            }
        }
    }
}
