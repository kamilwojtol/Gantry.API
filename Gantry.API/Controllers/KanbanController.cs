using Gantry.API.Data;
using Gantry.API.Dtos;
using Gantry.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        readonly AppDbContext _dbContext;

        public KanbanController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("{kanbanId}")]
        async public Task<ActionResult> GetKanbanById(int kanbanId)
        {

            var foundKanban = await _dbContext.KanbanBoards.Include(k => k.Tasks).FirstOrDefaultAsync(k => k.Id == kanbanId);
            if (foundKanban == null)
            {
                return NotFound();
            }

            return Ok(foundKanban);
        }

        [HttpDelete]
        [Route("{kanbanId}")]
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
        async public Task<ActionResult> CreateKanban(EditKanbanDto kanbanBoard)
        {
            var newKanban = new Kanban()
            {
                Title = kanbanBoard.Title,
                Tasks = (kanbanBoard.Tasks != null && kanbanBoard.Tasks.Count > 0) ? kanbanBoard.Tasks : null,
            }; 

            _dbContext.KanbanBoards.Add(newKanban);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetKanbanById),
                new { kanbanId = newKanban.Id },
                newKanban
            );
        }

        [HttpPut]
        [Route("{kanbanId}")]
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
