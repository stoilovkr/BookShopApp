using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentitiesController : ControllerBase
    {
        private IIdentitiesService identitiesService;

        public IdentitiesController(IIdentitiesService _identitiesService)
        {
            identitiesService = _identitiesService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Identity loginParam)
        {
            if (identitiesService.Authenticate(loginParam.Username, loginParam.Password))
                return new OkResult();
            return new BadRequestObjectResult(new { message = "Username or password is incorrect." });
        }

        [HttpPost("addidentity")]
        public IActionResult AddIdentity([FromBody] Identity loginParam)
        {
            if (identitiesService.AddIdentity(loginParam) != -1)
            {
                //Return redirect to catalog...
                return new OkResult();
            }
            return new BadRequestObjectResult(new { message = "Username already exists" });
        }
    }
}