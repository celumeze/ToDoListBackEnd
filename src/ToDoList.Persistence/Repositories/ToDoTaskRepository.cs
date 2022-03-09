using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Domain.Entities;

namespace ToDoList.Persistence.Repositories
{
    public class ToDoTaskRepository : BaseRepository<ToDoTask>, IToDoTaskRepository
    {
        public ToDoTaskRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
