using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Domain.Entities;

namespace TodoList.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<ToDoTask>> GetToDoTasksRepository()
        {
            var todoTaskAId = Guid.Parse("96735769-91d1-46cc-a7c2-e69b3703e540");
            var todoTaskBId = Guid.Parse("dc02d6e3-1505-410e-850c-b72b44bc3c8b");
            var todoTaskCId = Guid.Parse("505835dc-daa9-4269-bfa8-8ead10796f7c");

            var tasks = new List<ToDoTask>()
            {

               new ToDoTask
               {
                   ToDoTaskId = todoTaskAId,
                   Title = "Title A",
                   Description = "Task A Description",
                   CreatedBy = "SYSTEM",
                   CreatedDate = DateTime.Now,
               },

               new ToDoTask
               {
                   ToDoTaskId = todoTaskBId,
                   Title = "Title B",
                   Description = "Task B Description",
                   CreatedBy = "SYSTEM",
                   CreatedDate = DateTime.Now,
               },

               new ToDoTask
               {
                   ToDoTaskId = todoTaskAId,
                   Title = "Title C",
                   Description = "Task C Description",
                   CreatedBy = "SYSTEM",
                   CreatedDate = DateTime.Now,
               },

            };

            var mockToDoTaskRepository = new Mock<IAsyncRepository<ToDoTask>>();
            mockToDoTaskRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(tasks);

            return mockToDoTaskRepository;

        }

        public static Mock<IAsyncRepository<ToDoTask>> GetToDoTaskRepository()
        {
            var todoTaskAId = Guid.Parse("96735769-91d1-46cc-a7c2-e69b3703e540");
            var todoTaskBId = Guid.Parse("dc02d6e3-1505-410e-850c-b72b44bc3c8b");
            var todoTaskCId = Guid.Parse("505835dc-daa9-4269-bfa8-8ead10796f7c");

            var tasks = new List<ToDoTask>()
            {

               new ToDoTask
               {
                   ToDoTaskId = todoTaskAId,
                   Title = "Title A",
                   Description = "Task A Description",
                   CreatedBy = "SYSTEM",
                   CreatedDate = DateTime.Now,
               },

               new ToDoTask
               {
                   ToDoTaskId = todoTaskBId,
                   Title = "Title B",
                   Description = "Task B Description",
                   CreatedBy = "SYSTEM",
                   CreatedDate = DateTime.Now,
               },

               new ToDoTask
               {
                   ToDoTaskId = todoTaskAId,
                   Title = "Title C",
                   Description = "Task C Description",
                   CreatedBy = "SYSTEM",
                   CreatedDate = DateTime.Now,
               },

            };

            var mockToDoTaskRepository = new Mock<IAsyncRepository<ToDoTask>>();
            mockToDoTaskRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(tasks);
            mockToDoTaskRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(
                (Guid id) => {
                    return tasks.FirstOrDefault(t => t.ToDoTaskId == id);
                });
            mockToDoTaskRepository.Setup(repo => repo.AddAsync(It.IsAny<ToDoTask>())).ReturnsAsync((ToDoTask todoTask) =>
            {
                tasks.Add(todoTask);
                return todoTask;

            });

            mockToDoTaskRepository.Setup(repo => repo.RemoveAsync(It.IsAny<ToDoTask>()));

            return mockToDoTaskRepository;

        }
    }
}
