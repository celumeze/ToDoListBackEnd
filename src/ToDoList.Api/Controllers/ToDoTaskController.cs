using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.Feature.Commands;
using ToDoList.Application.Feature.Commands.DeleteToDoTask;
using ToDoList.Application.Feature.Commands.AddToDoTask;
using ToDoList.Application.Feature.Queries.GetToDoTaskList;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("all", Name = "GetAllTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ToDoTaskListVm>>> GetToDoTasks()
        {
            var todoTasks = await _mediator.Send(new ToDoTaskListQuery());

            return Ok(todoTasks);
        }

        [HttpPost(Name = "AddTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> AddToDoTask([FromBody] AddToDoTaskCommand addToDoTaskCommand)
        {
            var id = await _mediator.Send(addToDoTaskCommand);
            return Ok(id);
        }

        [HttpDelete(Name = "RemoveTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RemoveToDoTask(Guid id)
        {
            var deleteToDoTask = new DeleteToDoTaskCommand() { ToDoTaskId = id };
             await _mediator.Send(deleteToDoTask);
            return NoContent();
        }
    }
}
