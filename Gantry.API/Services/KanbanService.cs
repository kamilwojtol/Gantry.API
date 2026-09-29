using Gantry.API.Data;
using Gantry.API.Dtos;
using Gantry.API.Interfaces;
using Gantry.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Gantry.API.Services
{
    public class KanbanService : IKanbanService
    {
        readonly AppDbContext _dbContext;

        public KanbanService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async public Task<Kanban> CreateKanban(EditKanbanDto kanbanBoard)
        {
            var newKanban = new Kanban()
            {
                Title = kanbanBoard.Title,
                Description = kanbanBoard.Description,
                Tasks = (kanbanBoard.Tasks != null && kanbanBoard.Tasks.Count > 0) ? kanbanBoard.Tasks : null,
            };

            _dbContext.KanbanBoards.Add(newKanban);

            await _dbContext.SaveChangesAsync();

            return newKanban;
        }

        async public Task<Kanban> EditKanbanById(int kanbanId, EditKanbanDto editKanbanDto)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);


            if (foundKanban == null)
            {
                return null;
            }

            foundKanban.Title = editKanbanDto.Title;
            foundKanban.Description = editKanbanDto.Description;

            await _dbContext.SaveChangesAsync();

            return foundKanban;
        }

        async public Task<List<Kanban>> GetAllKanbanBoards()
        {
            var kanbanBoards = await _dbContext.KanbanBoards.ToListAsync();

            return kanbanBoards;
        }

        async public Task<Kanban> GetKanbanById(int kanbanId)
        {
            var foundKanban = await _dbContext.KanbanBoards.Include(k => k.Tasks).FirstOrDefaultAsync(k => k.Id == kanbanId);
            if (foundKanban == null)
            {
                return null;
            }

            return foundKanban;
        }

        async public Task<Kanban> RemoveKanbanById(int kanbanId)
        {
            var foundKanban = await _dbContext.KanbanBoards.FindAsync(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            _dbContext.KanbanBoards.Remove(foundKanban);

            await _dbContext.SaveChangesAsync();

            return foundKanban;
        }
    }
}
