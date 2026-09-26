using Gantry.API.Dtos;

namespace Gantry.API.Interfaces
{
    public interface IKanbanService
    {
        public Task<List<Models.Kanban>> GetAllKanbanBoards();
        public Task<Models.Kanban> GetKanbanById(int kanbanId);
        public Task<Models.Kanban> RemoveKanbanById(int kanbanId);
        public Task<Models.Kanban> CreateKanban(EditKanbanDto kanbanBoard);
        public Task<Models.Kanban> EditKanbanById(int kanbanId, EditKanbanDto editKanbanDto);
    }
}
