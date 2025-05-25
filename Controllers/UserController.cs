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
        public IActionResult CreteUser([FromBody] UserInfo userInfo)
        {
            ResultViewModel<UserInfo> result;
            try
            {
                UserInfo userCreated = _userInfoBusiness.Create(userInfo);
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
        public IActionResult GetUser([FromRoute] int id)
        {
            _userInfoBusiness.GetById(id);
            return Ok("Sucesso");
        }

        [HttpGet("range/skip={skip:int}&take={take:int}")]
        public IActionResult GetUserByRange([FromRoute] int skip, [FromRoute] int take)
        {
            _userInfoBusiness.GetByRange(skip, take);

            return Ok("Sucesso");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _userInfoBusiness.Delete(id);
            return Ok("Sucesso");
        }
    }
}
