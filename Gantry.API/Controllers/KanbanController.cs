using Gantry.API.Data;
using Gantry.API.Dtos;
using Gantry.API.Interfaces;
using Gantry.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        readonly IKanbanService _kanbanService;

        public KanbanController(IKanbanService kanbanService)
        {
            _kanbanService = kanbanService;
        }

        [HttpGet]
        async public Task<ActionResult> GetAllKanbanBoards()
        {
            var kanbanBoards = await _kanbanService.GetAllKanbanBoards();

            return Ok(kanbanBoards);
        }

        [HttpGet]
        [Route("{kanbanId}")]
        async public Task<ActionResult> GetKanbanById(int kanbanId)
        {
            var foundKanban = await _kanbanService.GetKanbanById(kanbanId);

            return Ok(foundKanban);
        }

        [HttpDelete]
        [Route("{kanbanId}")]
        async public Task<ActionResult> RemoveKanbanById(int kanbanId)
        {
            await _kanbanService.RemoveKanbanById(kanbanId);

            return Ok();
        }

        [HttpPost]
        async public Task<ActionResult> CreateKanban(EditKanbanDto kanbanBoard)
        {
           var newKanban = await _kanbanService.CreateKanban(kanbanBoard);

            return CreatedAtAction(
                nameof(GetKanbanById),
                new { kanbanId = newKanban.Id },
                newKanban
            );
        }

        [HttpPut]
        [Route("{kanbanId}")]
        async public Task<ActionResult> EditKanbanById(int kanbanId, EditKanbanDto editKanbanDto)
        {
            await _kanbanService.EditKanbanById(kanbanId, editKanbanDto);

            return Ok();
        }
    }
}
