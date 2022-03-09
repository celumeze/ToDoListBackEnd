using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Feature.Commands.DeleteToDoTask
{
    public class DeleteToDoTaskCommand : IRequest
    {
        public Guid ToDoTaskId { get; set; }
    }
}
