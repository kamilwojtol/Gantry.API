using Gantry.API.Data;
using Gantry.API.Dtos;
using Gantry.API.Models;
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

        [HttpPost]
        public ActionResult CreateKanban(EditKanbanDto kanbanBoard)
        {
            var newKanban = new Kanban()
            {
                Id = _dbContext.KanbanBoards.Count() + 1,
                Title = kanbanBoard.Title,
                Tasks = new List<Models.Task>()
            }; 

            _dbContext.KanbanBoards.Add(newKanban);

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
