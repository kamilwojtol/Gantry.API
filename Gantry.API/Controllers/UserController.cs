using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Controllers
{
    [Route("/api/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{userId}")]
        public ActionResult getUserById(int userId)
        {
            return Ok();
        }


    }
}
