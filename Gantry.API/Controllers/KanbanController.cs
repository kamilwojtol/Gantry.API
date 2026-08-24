using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        [Route("{kanbanId}")]
        public ActionResult GetKanbanById(int kanbanId)
        {
            return Ok();
        }
    }
}
