using Gantry.API.Data;
using Gantry.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/{kanbanId}")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        readonly AppDbContext _dbContext;

        public KanbanController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetKanbanById(int kanbanId)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);

            if (foundKanban == null)
            {
                return NotFound();
            }

            return Ok(foundKanban);
        }

        [HttpDelete]
        public ActionResult RemoveKanbanById(int kanbanId)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);

            if (foundKanban == null)
            {
                return NotFound();
            }

            _dbContext.KanbanBoards.Remove(foundKanban);

            return Ok();
        }

        [HttpPut]
        public ActionResult EditKanbanById(int kanbanId, EditKanbanDto editKanbanDto )
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);
        

            if (foundKanban == null)
            {
                return NotFound();
            }

            foundKanban.Title = editKanbanDto.Title;

            return Ok();
        }
    }
}
