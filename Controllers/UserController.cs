using FamilyStoryApi.Business;
using FamilyStoryApi.Model;
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

        [HttpPost]
        public IActionResult GetUser([FromBody] UserInfo userInfo)
        {
            _userInfoBusiness.Create(userInfo);
            return Ok("Sucesso");
        }
    }
}
