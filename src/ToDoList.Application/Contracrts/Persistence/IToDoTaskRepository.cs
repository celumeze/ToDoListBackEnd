using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracrts.Persistence
{
    public interface IToDoTaskRepository : IAsyncRepository<ToDoTask>
    {
        //public Task GetToDoTaskList();

    }
}
