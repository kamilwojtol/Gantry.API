using Gantry.API.Dtos;
using Gantry.API.Interfaces;
using Gantry.API.Utils;
using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Store
{
    public class GantryStore
    {
        public GetKanbanDto store = new GetKanbanDto()
        {
          Id = 1,
          Title = "GantryApp",
          Tasks = new List<ITask>()
          {
             new ITask()
             {
                 Id = 1,
                 Author = "Kamil Wojtol",
                 CreatedAt = DateTime.Now,
                 Deadline = DateTime.Now,
                 Name = "Code this app everyday",
                 Description = "Let's ship this",
                 Status = TaskStatusCode.IN_PROGRESS,
             },
             new ITask()
             {
                 Id = 2,
                 Author = "Kamil Wojtol",
                 CreatedAt = DateTime.Now,
                 Deadline = DateTime.Now,
                 Name = "Wash dishes",
                 Description = "Come on, everyone needs to this",
                 Status = TaskStatusCode.TO_DO,
             },
             new ITask()
             {
                 Id = 3,
                 Author = "Kamil Wojtol",
                 CreatedAt = DateTime.Now,
                 Deadline = DateTime.Now,
                 Name = "Buy flowers",
                 Description = "Nice suprise for your loved one",
                 Status = TaskStatusCode.DONE,
             },
          }

        };
    }
}
