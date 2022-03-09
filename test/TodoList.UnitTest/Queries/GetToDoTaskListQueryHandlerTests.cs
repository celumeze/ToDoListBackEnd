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
using ToDoList.Application.Feature.Queries.GetToDoTaskList;
using ToDoList.Application.Profiles;
using ToDoList.Domain.Entities;
using Xunit;

namespace TodoList.UnitTest.Queries
{
    public class GetToDoTaskListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<ToDoTask>> _mockToDoTaskRepository;

        public GetToDoTaskListQueryHandlerTests()
        {
            _mockToDoTaskRepository = RepositoryMocks.GetToDoTasksRepository();
            var configProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configProvider.CreateMapper();
        }

        [Fact]
        public async Task ToDoTaskListQueryHandler_OnToDoTaskListQueryHandler_ShouldReturnToDoTaskList()
        {
            var handler = new ToDoTaskListQueryHandler(_mockToDoTaskRepository.Object, _mapper);

            var result = await handler.Handle(new ToDoTaskListQuery(), CancellationToken.None);

            result.Should().BeOfType<List<ToDoTaskListVm>>();
            result.Should().HaveCount(3);
        }
    }
}
