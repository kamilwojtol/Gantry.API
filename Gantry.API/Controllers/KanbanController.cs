using Gantry.API.Dtos;
using Gantry.API.Store;
using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/{kanbanId}")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        readonly GantryStore _gantryStore;

        public KanbanController(GantryStore gantryStore)
        {
            _gantryStore = gantryStore;
        }

        [HttpGet]
        public ActionResult GetKanbanById(int kanbanId)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return NotFound();
            }

            return Ok(foundKanban);
        }

        [HttpDelete]
        public ActionResult RemoveKanbanById(int kanbanId)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return NotFound();
            }

            _gantryStore.kanbanStore.Remove(foundKanban);

            return Ok();
        }

        [HttpPut]
        public ActionResult EditKanbanById(int kanbanId, EditKanbanDto editKanbanDto )
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return NotFound();
            }

            foundKanban.Title = editKanbanDto.Title;
            foundKanban.Tasks = editKanbanDto.Tasks;

            return Ok();
        }
    }
}
