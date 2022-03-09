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
using ToDoList.Application.Profiles;
using ToDoList.Domain.Entities;
using Xunit;

namespace TodoList.UnitTest.Commands
{
    public class AddToDoTaskCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<ToDoTask>> _mockToDoRepository;  
        private readonly AddToDoTaskCommandValidator _validator;

        public AddToDoTaskCommandHandlerTest()
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
        public async Task AddToDoTaskCommandHandler_OnHandle_ShouldAddIntoStore()
        {
            var handler = new AddToDoTaskCommandHandler(_mockToDoRepository.Object, _mapper);

            var query = new AddToDoTaskCommand
            {
                ToDoTaskId = Guid.Parse("5f10d348-c740-4cde-875e-3b6716f39675"),
                Title = "Title ATest",
                Description = "Task Description ATest"
            };
            await handler.Handle(query, CancellationToken.None);

            var todoTask = await _mockToDoRepository.Object.GetByIdAsync(query.ToDoTaskId);
            var allToDoTasks = await _mockToDoRepository.Object.ListAllAsync();
            todoTask.Title.Should().Be("Title ATest");
            todoTask.Description.Should().Be("Task Description ATest");
            allToDoTasks.Count.Should().Be(4);
        }

        [Fact]
        public async void AddToDoTaskCommandValidator_WhenTitleIsNullOrEmpty_SShouldBeFalse()
        {
            var query = new AddToDoTaskCommand
            {
                ToDoTaskId = Guid.Parse("83c0a850-e7d2-42d8-9754-a5fde37c2355"),
                Title = "",
                Description = "Test Description 34"
            };

            (await _validator.ValidateAsync(query)).IsValid.Should().BeFalse();
        }

        [Fact]
        public async void AddToDoTaskCommandValidator_WhenDescriptionIsNullOrEmpty_SShouldBeFalse()
        {
            var query = new AddToDoTaskCommand
            {
                ToDoTaskId = Guid.Parse("83c0a850-e7d2-42d8-9754-a5fde37c2355"),
                Title = "Test Title 23",
                Description = ""
            };

            (await _validator.ValidateAsync(query)).IsValid.Should().BeFalse();
        }
    }
}
