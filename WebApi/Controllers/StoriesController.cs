using FamilyStoryApi.Application.Commom.Results;
using FamilyStoryApi.Application.Stories.Commands;
using FamilyStoryApi.Application.Stories.Handlers;
using FamilyStoryApi.Application.Stories.Queries.GetStoryById;
using FamilyStoryApi.Application.Stories.Results;
using FamilyStoryApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStoryApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
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

        [HttpGet("by-id/{id:int}")]
        //[Authorize(Roles = "story_create")]
        public async Task<IActionResult> CreateStory(
            [FromServices] GetStoryByIdHandler handler,
            [FromRoute] int id )
        {

            GetStoryByIdQuery query = new() { StoryId = id };
            CommandResult <GetStoryByIdResult> cmResult = await handler.HandleAsync(query);
            ResultViewModel<CommandResult<GetStoryByIdResult>> rvModel;

            if (handler.IsValid)
            {
                rvModel = new(data: cmResult);
                return Ok(rvModel);
            }
            else
            {
                rvModel = new(errors: [.. handler.Notifications]);
                return BadRequest(rvModel);
            }
        }
    }
}
