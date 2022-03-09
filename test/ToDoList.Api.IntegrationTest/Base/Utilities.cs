using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using ToDoList.Persistence;

namespace ToDoList.Api.IntegrationTest.Base
{
    public class Utilities
    {
        public static void InitializeDb(AppDbContext context)
        {
            var todoTaskAId = Guid.Parse("96735769-91d1-46cc-a7c2-e69b3703e540");
            var todoTaskBId = Guid.Parse("dc02d6e3-1505-410e-850c-b72b44bc3c8b");
            var todoTaskCId = Guid.Parse("505835dc-daa9-4269-bfa8-8ead10796f7c");

            //var tasks = new List<ToDoTask>()
            // {

            context.ToDoTasks.Add(new ToDoTask
            {
                ToDoTaskId = todoTaskAId,
                Title = "Title A",
                Description = "Task A Description",
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.Now,
            });

            context.ToDoTasks.Add(new ToDoTask
            {
                ToDoTaskId = todoTaskBId,
                Title = "Title B",
                Description = "Task B Description",
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.Now,
            });

            context.ToDoTasks.Add(new ToDoTask
            {
                ToDoTaskId = todoTaskAId,
                Title = "Title C",
                Description = "Task C Description",
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.Now,
            });

            context.SaveChanges();
           // };
        }
    }
}
