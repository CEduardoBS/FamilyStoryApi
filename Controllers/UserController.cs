using FamilyStoryApi.Business;
using FamilyStoryApi.Model;
using FamilyStoryApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoBusiness _userInfoBusiness;

        public UserController(IUserInfoBusiness userInfoBusiness)
        {
            _userInfoBusiness = userInfoBusiness;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreteUser([FromBody] UserInfo userInfo)
        {
            ResultViewModel<UserInfo> result;
            try
            {
                UserInfo userCreated = await _userInfoBusiness.Create(userInfo);
                result = new(data: userCreated);
            }
            catch (Exception err)
            {
                result = new(error: err.ToString());
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
            await _userInfoBusiness.GetById(id);
            return Ok("Sucesso");
        }

        [HttpGet("range/skip={skip:int}&take={take:int}")]
        public async Task<IActionResult> GetUserByRange([FromRoute] int skip, [FromRoute] int take)
        {
            await _userInfoBusiness.GetByRange(skip, take);

            return Ok("Sucesso");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userInfoBusiness.Delete(id);
            return Ok("Sucesso");
        }
    }
}
