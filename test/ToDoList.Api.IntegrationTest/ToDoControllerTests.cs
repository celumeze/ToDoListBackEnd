using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Api.IntegrationTest.Base;
using ToDoList.Application.Feature.Commands.AddToDoTask;
using ToDoList.Application.Feature.Queries.GetToDoTaskList;
using Xunit;

namespace ToDoList.Api.IntegrationTest
{
    public class ToDoTaskControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ToDoTaskControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CustomerController_GetExisitingToDoTasks_ShouldReturnNonEmptyList()
        {
            var client = _factory.GetAnonymoustClient();

            var response = await client.GetAsync("/api/todotask/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ToDoTaskListVm>>(responseString);

            result.Should().BeOfType<List<ToDoTaskListVm>>();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task CustomerController_AddNewCustomer_ReturnsNewCustomer()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), "api/todotask/AddTask");
            var client = _factory.GetAnonymoustClient();
            var query = new AddToDoTaskCommand
            {
                ToDoTaskId = Guid.Parse("5f10d348-c740-4cde-875e-3b6716f39675"),
                Title = "Title ATest",
                Description = "Task Description ATest"
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(request.RequestUri, request.Content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taskId = await response.Content.ReadAsStringAsync();
            var toDoTaskId = JsonConvert.DeserializeObject<Guid>(taskId);

            toDoTaskId.Should().Be("5f10d348-c740-4cde-875e-3b6716f39675");            
        }
    }
}
