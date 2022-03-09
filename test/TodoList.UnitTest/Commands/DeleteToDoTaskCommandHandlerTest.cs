using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoList.UnitTest.Mocks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Application.Feature.Commands.AddToDoTask;
using ToDoList.Application.Feature.Commands.DeleteToDoTask;
using ToDoList.Application.Profiles;
using ToDoList.Domain.Entities;
using Xunit;

namespace TodoList.UnitTest.Commands
{
    public class DeleteToDoTaskCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<ToDoTask>> _mockToDoRepository;
        private readonly AddToDoTaskCommandValidator _validator;

        public DeleteToDoTaskCommandHandlerTest()
        {
            _mockToDoRepository = RepositoryMocks.GetToDoTaskRepository();
            var configProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configProvider.CreateMapper();
            _validator = new AddToDoTaskCommandValidator();
        }



        [Fact]
        public async Task DeleteToDoTaskCommandHandler_OnHandle_ShouldAddIntoStore()
        {
            var handler = new DeleteToDoTaskCommandHandler(_mockToDoRepository.Object, _mapper);
            var taskToDelete = await _mockToDoRepository.Object.GetByIdAsync(Guid.Parse("96735769-91d1-46cc-a7c2-e69b3703e540"));
            var query = new DeleteToDoTaskCommand
            {
                ToDoTaskId = taskToDelete.ToDoTaskId,                
            };
            await handler.Handle(query, CancellationToken.None);

            //var todoTask = await _mockToDoRepository.Object.GetByIdAsync(query.ToDoTaskId);
            var allToDoTasks = await _mockToDoRepository.Object.ListAllAsync();
            //todoTask.Title.Should().Be("Title ATest");
            //todoTask.Description.Should().Be("Task Description ATest");
            allToDoTasks.Count.Should().Be(3);
        }
    }
}
